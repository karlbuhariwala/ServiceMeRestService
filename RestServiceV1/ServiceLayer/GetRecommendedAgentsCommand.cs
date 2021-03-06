﻿// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetRecommendedAgentsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts.InApp;
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Command to get the reccomended agents for a new case
    /// </summary>
    public class GetRecommendedAgentsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetRecommendedAgentsRequestContainer requestContainer = context.InParam as GetRecommendedAgentsRequestContainer;
            GetRecommendedAgentsReturnContainer returnContainer = new GetRecommendedAgentsReturnContainer();

            const int maxTagsCount = 10;
            const int maxAgentCount = int.MaxValue;

            // Todo: Make lists from Json
            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@deleted", false } };
            for (int i = 0; i < requestContainer.CaseDetails.Tags.Count && i < maxTagsCount; i++)
            {
                parameters.Add("@tag" + i, requestContainer.CaseDetails.Tags[i]);
            }

            DataSet agentIdsresult = sqlProvider.ExecuteQuery(SqlQueries.GetAgentsForTagQuery(requestContainer.CaseDetails.Tags.Take(maxTagsCount).ToList<string>()), parameters);

            List<string> agentIds = new List<string>();
            returnContainer.RecommendedAgents = new List<UserProfile>();
            if (agentIdsresult.Tables.Count > 0 && agentIdsresult.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in agentIdsresult.Tables[0].Rows)
                {
                    bool isEnterpriseTag;
                    bool.TryParse(row["IsEnterpriseTag"].ToString(), out isEnterpriseTag);
                    if (isEnterpriseTag)
                    {
                        UserProfile userProfile = new UserProfile();
                        userProfile.Name = Constants.TagKeywordIndicator + row["Tag"].ToString();
                        userProfile.UserId = string.Empty;
                        double tempDouble;
                        double.TryParse(row["EnterpriseTagRating"].ToString(), out tempDouble);
                        userProfile.AgentRating = tempDouble;

                        int tempInt;
                        int.TryParse(row["EnterpriseTagRatingCount"].ToString(), out tempInt);
                        userProfile.AgentRatingCount = tempInt;


                        int.TryParse(row["EnterpriseTagPositiveRatingCount"].ToString(), out tempInt);
                        userProfile.AgentPositiveRatingCount = tempInt;

                        returnContainer.RecommendedAgents.Add(userProfile);
                        continue;
                    }

                    // Todo: Change to json
                    agentIds.AddRange(row["AgentIdGroup1"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>());
                    agentIds.AddRange(row["AgentIdGroup2"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>());
                }
            }

            parameters = new Dictionary<string, object>() { { "@deleted", false } };
            for (int i = 0; i < agentIds.Count && i < maxAgentCount; i++)
            {
                parameters.Add("@userId" + i, agentIds[i]);
            }

            Coordinates coordinates = new Coordinates(requestContainer.UserProfile.UserLatitude, requestContainer.UserProfile.UserLongitude);
            if (requestContainer.CaseDetails.AnotherAddress != null)
            {
                IGeolocationProvider geolocationProvider = (IGeolocationProvider)ProviderFactory.Instance.CreateProvider<IGeolocationProvider>(null);
                coordinates = geolocationProvider.GetCoordinates(requestContainer.CaseDetails.AnotherAddress);
            }

            parameters.Add("@Lat", coordinates.Latitude);
            parameters.Add("@Lng", coordinates.Longitude);

            DataSet agentInfoResult = sqlProvider.ExecuteQuery(SqlQueries.GetUsersByIdsQuery(agentIds.Take(maxAgentCount).ToList<string>(), coordinates), parameters);

            List<UserProfile> agentProfiles = new List<UserProfile>();
            if (agentInfoResult.Tables.Count > 0 && agentInfoResult.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in agentInfoResult.Tables[0].Rows)
                {
                    // Todo: Change to json
                    UserProfile agentProfile = new UserProfile();
                    agentProfile.UserId = row["UserId"].ToString();
                    agentProfile.Name = row["Name"].ToString();
                    double tempDouble;
                    if (double.TryParse(row["AgentRating"].ToString(), out tempDouble))
                    {
                        agentProfile.AgentRating = tempDouble;
                    }
                    else
                    {
                        // Todo: Log
                    }

                    int tempInt;
                    if (int.TryParse(row["AgentRatingCount"].ToString(), out tempInt))
                    {
                        agentProfile.AgentRatingCount = tempInt;
                    }
                    else
                    {
                        // Todo: Log
                    }

                    int.TryParse(row["AgentPositiveRatingCount"].ToString(), out tempInt);
                    agentProfile.AgentPositiveRatingCount = tempInt;

                    agentProfiles.Add(agentProfile);
                }
            }

            // Todo: Enterprise tags are not ranked.
            IRankingProvider rankingProvider = (IRankingProvider)ProviderFactory.Instance.CreateProvider<IRankingProvider>(null);
            rankingProvider.SortByRank(agentProfiles);

            returnContainer.RecommendedAgents.AddRange(agentProfiles.Take(5).ToList());
            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}