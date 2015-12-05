// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentsForCaseCommand.cs

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
    /// Get agents for case command
    /// </summary>
    public class GetAgentsForCaseCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentsForCaseRequestContainer requestContainer = context.InParam as GetAgentsForCaseRequestContainer;
            GetAgentsForCaseReturnContainer returnContainer = new GetAgentsForCaseReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@caseId", requestContainer.CaseId);
            parameters.Add("@deleted", false);
            parameters.Add("@blocked", false);

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetAgentsForUserCase, parameters);
            if (result.Tables.Count < 1)
            {
                throw new ApplicationException("Query failed");
            }

            returnContainer.Agents = new List<UserProfile>();
            foreach (DataRow row in result.Tables[0].Rows)
            {
                UserProfile userProfile = new UserProfile();
                userProfile.UserId = row["AgentId"].ToString();
                userProfile.Name = row["Name"].ToString();

                double tempDouble = 0;
                double.TryParse(row["AgentRating"].ToString(), out tempDouble);
                userProfile.AgentRating = tempDouble;

                int tempInt = 0;
                int.TryParse(row["AgentRatingCount"].ToString(), out tempInt);
                userProfile.AgentRatingCount = tempInt;

                returnContainer.Agents.Add(userProfile);
            }

            // Todo: Locality and order
            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}