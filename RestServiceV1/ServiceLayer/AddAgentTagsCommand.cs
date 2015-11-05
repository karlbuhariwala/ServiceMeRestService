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

            returnContainer.TagsThatNeedCodes = new List<string>();
            foreach (DataRow row in result.Tables[0].Rows)
            {
                string tag = row["Tag"].ToString();
                bool tempBool = false;
                bool.TryParse(row["IsEnterpriseTag"].ToString(), out tempBool);
                if (tempBool)
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
                            tagsUserMap.Add(tag, row["AgentIdGroup1"].ToString() + Constants.QuerySeparator + requestContainer.AgentId);
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
                    tagsUserMap.Add(tag, row["AgentIdGroup1"].ToString() + Constants.QuerySeparator + requestContainer.AgentId);
                }
            }

            // Make this concurrent and is not thread safe.
            if (returnContainer.ReturnCode == ReturnCodes.C101)
            {
                for (int i = 0; i < requestContainer.TagCodeList.Count && i < maxTagsCount; i++)
                {
                    Dictionary<string, object> parametersForUpdate = new Dictionary<string, object>();
                    parametersForUpdate.Add("@tag", requestContainer.TagCodeList[i].First);
                    parametersForUpdate.Add("@userIds", tagsUserMap[requestContainer.TagCodeList[i].First]);

                    sqlProvider.ExecuteQuery(SqlQueries.UpdateTagWithInfo, parametersForUpdate);
                }
            }

            return returnContainer;
        }
    }
}