// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddAgentTagsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using DataContracts.InApp;
    /// <summary>
    /// Add agent tags command class
    /// </summary>
    public class AddAgentTagsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            AddAgentTagsRequestContainer requestContainer = context.InParam as AddAgentTagsRequestContainer;
            AddAgentTagsReturnContainer returnContainer = new AddAgentTagsReturnContainer();

            int maxTagsCount = 10;

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@deleted", false);
            for (int i = 0; i < requestContainer.TagCodeList.Count && i < maxTagsCount; i++)
            {
                parameters.Add("@tag" + i, requestContainer.TagCodeList[i].First);
            }

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetTagInfoForAddingNewTagToAgentQuery(requestContainer.TagCodeList.Select(x => x.First).Take(maxTagsCount).ToList<string>()), parameters);
            if (result.Tables.Count < 1)
            {
                throw new ApplicationException("Query errored out");
            }

            returnContainer.ReturnCode = ReturnCodes.C101;

            Dictionary<string, string> tagsUserMap = new Dictionary<string, string>();

            // Todo: Need to check if user already on the tag and not repeat. Edit 1/18/2016: I believe here we are talking about for inserting below again in the DB.
            returnContainer.TagsThatNeedCodes = new List<string>();
            foreach (DataRow row in result.Tables[0].Rows)
            {
                string tag = row["Tag"].ToString();
                bool isEnterpriseTag = false;
                bool.TryParse(row["IsEnterpriseTag"].ToString(), out isEnterpriseTag);
                List<string> userIds = row["AgentIdGroup1"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if(userIds.Contains(requestContainer.AgentProfile.UserId, StringComparer.OrdinalIgnoreCase))
                {
                    tagsUserMap.Add(tag, row["AgentIdGroup1"].ToString());
                    continue;
                }

                if (isEnterpriseTag)
                {
                    DateTimeOffset tempDateTimeOffset = new DateTimeOffset(new DateTime(1900, 1, 1));
                    DateTimeOffset.TryParse(row["DateTimeTagCode"].ToString(), out tempDateTimeOffset);
                    if(tempDateTimeOffset > DateTimeOffset.UtcNow)
                    {
                        int tempInt = -1;
                        int.TryParse(row["Code"].ToString(), out tempInt);
                        if (tempInt != requestContainer.TagCodeList.FirstOrDefault(x => x.First == tag).Second)
                        {
                            returnContainer.TagWithIncorrectCode = tag;
                            returnContainer.ReturnCode = ReturnCodes.C103;
                            return returnContainer;
                        }
                        else
                        {
                            tagsUserMap.Add(tag, row["AgentIdGroup1"].ToString() + Constants.QuerySeparator + requestContainer.AgentProfile.UserId);
                        }
                    }
                    else
                    {
                        returnContainer.TagsThatNeedCodes.Add(tag);
                        returnContainer.ReturnCode = ReturnCodes.C102;
                    }
                }
                else
                {
                    tagsUserMap.Add(tag, row["AgentIdGroup1"].ToString() + Constants.QuerySeparator + requestContainer.AgentProfile.UserId);
                }
            }

            Coordinates topLeft;
            Coordinates bottomRight;
            IGeoAreaProvider geoAreaProvider = (IGeoAreaProvider)ProviderFactory.Instance.CreateProvider<IGeoAreaProvider>(null);
            geoAreaProvider.GetBoundary(new Coordinates(requestContainer.AgentProfile.UserLatitude, requestContainer.AgentProfile.UserLongitude), requestContainer.AgentProfile.AreaOfService, out topLeft, out bottomRight);

            // Make this concurrent and is not thread safe.
            if (returnContainer.ReturnCode == ReturnCodes.C101)
            {
                List<string> tagsToAdd = new List<string>();
                for (int i = 0; i < requestContainer.TagCodeList.Count && i < maxTagsCount; i++)
                {
                    Dictionary<string, object> parametersForUpdate = new Dictionary<string, object>();
                    parametersForUpdate.Add("@tag", requestContainer.TagCodeList[i].First);
                    parametersForUpdate.Add("@userIds", tagsUserMap[requestContainer.TagCodeList[i].First]);

                    sqlProvider.ExecuteQuery(SqlQueries.UpdateTagWithInfo, parametersForUpdate);

                    tagsToAdd.Add(requestContainer.TagCodeList[i].First);
                }

                Dictionary<string, object> parametersForProfile = new Dictionary<string, object>();
                parametersForProfile.Add("@UserInfoName", null);
                parametersForProfile.Add("@UserInfoContactPref", null);
                parametersForProfile.Add("@UserInfoEmailAddress", null);
                parametersForProfile.Add("@UserInfoAddress", null);
                parametersForProfile.Add("@IsAgent", null);
                parametersForProfile.Add("@IsManager", null);
                parametersForProfile.Add("@LandingPage", null);
                parametersForProfile.Add("@Longitude", null);
                parametersForProfile.Add("@Latitude", null);
                parametersForProfile.Add("@AreaOfService", requestContainer.AgentProfile.AreaOfService);
                parametersForProfile.Add("@AreaOfServiceTopLeftLat", topLeft.Latitude);
                parametersForProfile.Add("@AreaOfServiceTopLeftLng", topLeft.Longitude);
                parametersForProfile.Add("@AreaOfServiceBottomRightLat", bottomRight.Latitude);
                parametersForProfile.Add("@AreaOfServiceBottomRightLng", bottomRight.Longitude);
                parametersForProfile.Add("@Tags", string.Join(Constants.QuerySeparator, tagsToAdd));
                parametersForProfile.Add("@userId", requestContainer.AgentProfile.UserId);
                sqlProvider.ExecuteQuery(SqlQueries.UpdateUserProfile, parametersForProfile);
            }

            return returnContainer;
        }
    }
}