// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentsForAutoCompleteCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Command to get the agents for autocomplete
    /// </summary>
    public class GetAgentsForAutoCompleteCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentsForAutoCompleteRequestContainer requestContainer = context.InParam as GetAgentsForAutoCompleteRequestContainer;
            GetAgentsForAutoCompleteReturnContainer returnContainer = new GetAgentsForAutoCompleteReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@deleted", false } };
            parameters.Add("@name", string.Format("%{0}%", requestContainer.Text));

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetAgentForAutoComplete, parameters);

            returnContainer.Agents = new List<UserProfile>();
            if (result.Tables.Count > 0)
            {
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    UserProfile agent = new UserProfile();
                    agent.Name = row["Name"].ToString();
                    agent.UserId = row["UserId"].ToString();
                    agent.PhoneNumber = row["PhoneNumber"].ToString();
                    double tempDouble;
                    double.TryParse(row["Rating"].ToString(), out tempDouble);
                    agent.Rating = tempDouble;

                    int tempInt;
                    int.TryParse(row["NumberOfRatings"].ToString(), out tempInt);
                    agent.NumberOfRatings = tempInt;

                    returnContainer.Agents.Add(agent);
                }
            }

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}