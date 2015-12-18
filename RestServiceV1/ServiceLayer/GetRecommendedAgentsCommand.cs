// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetRecommendedAgentsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using Providers.GeoLocation;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using DataContracts.InApp;

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
            const int maxAgentCount = 5;

            // Todo: Make lists from Json
            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@deleted", false } };
            for (int i = 0; i < requestContainer.CaseDetails.Tags.Count && i < maxTagsCount; i++)
            {
                parameters.Add("@tag" + i, requestContainer.CaseDetails.Tags[i]);
            }

            DataSet agentIdsresult = sqlProvider.ExecuteQuery(SqlQueries.GetAgentsForTagQuery(requestContainer.CaseDetails.Tags.Take(maxTagsCount).ToList<string>()), parameters);

            List<string> agentIds = new List<string>();
            if (agentIdsresult.Tables.Count > 0 && agentIdsresult.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in agentIdsresult.Tables[0].Rows)
                {
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

            IGeolocationProvider geolocationProvider = (IGeolocationProvider)ProviderFactory.Instance.CreateProvider<IGeolocationProvider>(null);
            Coordinates coordinates = geolocationProvider.GetCoordinates(requestContainer.CaseDetails.AnotherAddress);
            parameters.Add("@Lat", coordinates.Lattitude);
            parameters.Add("@Lng", coordinates.Longitude);

            DataSet agentInfoResult = sqlProvider.ExecuteQuery(SqlQueries.GetUsersByIdsQuery(agentIds.Take(maxAgentCount).ToList<string>()), parameters);

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

                    agentProfiles.Add(agentProfile);
                }
            }

            returnContainer.RecommendedAgents = agentProfiles;
            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}