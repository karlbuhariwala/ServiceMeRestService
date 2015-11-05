// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentDetailsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Command to get the agent's details
    /// </summary>
    public class GetAgentDetailsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentDetailsRequestContainer requestContainer = context.InParam as GetAgentDetailsRequestContainer;
            GetAgentDetailsReturnContainer returnContainer = new GetAgentDetailsReturnContainer();

            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@deleted", false } };
            List<string> usersToQuery = new List<string>();
            usersToQuery.Add(requestContainer.AgentId);
            usersToQuery.Add(requestContainer.UserId);
            for (int i = 0; i < usersToQuery.Count; i++)
            {
                parameters.Add("@userId" + i, usersToQuery[i]);
            }

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            DataSet agentInfoResult = sqlProvider.ExecuteQuery(SqlQueries.GetUsersByIdsQuery(usersToQuery), parameters);

            if (agentInfoResult.Tables.Count > 0 && agentInfoResult.Tables[0].Rows.Count == 2)
            {
                foreach (DataRow row in agentInfoResult.Tables[0].Rows)
                {
                    string userId = row["UserId"].ToString();

                    if (userId == requestContainer.AgentId)
                    {
                        // Todo: Change to json
                        UserProfile agentProfile = new UserProfile();
                        agentProfile.UserId = row["UserId"].ToString();
                        agentProfile.Name = row["Name"].ToString();
                        double tempDouble;
                        if (double.TryParse(row["Rating"].ToString(), out tempDouble))
                        {
                            agentProfile.Rating = tempDouble;
                        }
                        else
                        {
                            // Todo: Log
                        }

                        int tempInt;
                        if (int.TryParse(row["NumberOfRatings"].ToString(), out tempInt))
                        {
                            agentProfile.NumberOfRatings = tempInt;
                        }
                        else
                        {
                            // Todo: Log
                        }

                        agentProfile.AreaOfService = row["AreaOfService"].ToString();
                        agentProfile.Tags = row["Tags"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                        returnContainer.AgentProfile = agentProfile;
                    }
                    else
                    {
                        List<string> favoriteAgentsOfUser = row["FavoriteAgents"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                        returnContainer.IsFavorite = false;
                        if (favoriteAgentsOfUser.Contains(requestContainer.AgentId))
                        {
                            returnContainer.IsFavorite = true;
                        }
                    }
                }

                returnContainer.ReturnCode = ReturnCodes.C101;
            }
            else
            {
                // No agent found
                returnContainer.ReturnCode = ReturnCodes.C001;
            }

            return returnContainer;
        }
    }
}