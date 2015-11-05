// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetUserCaseDetailCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Get user case detail command
    /// </summary>
    public class GetUserCaseDetailCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetUserCaseDetailRequestContainer requestContainer = context.InParam as GetUserCaseDetailRequestContainer;
            GetUserCaseDetailReturnContainer returnContainer = new GetUserCaseDetailReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@caseId", requestContainer.CaseId);
            parameters.Add("@deleted", false);

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetUserCaseDetailsQuery, parameters);

            if (result.Tables.Count < 1)
            {
                throw new ApplicationException("Query failed");
            }

            if (result.Tables[0].Rows.Count != 1)
            {
                throw new ApplicationException("Query failed");
            }

            DataRow row = result.Tables[0].Rows[0];

            returnContainer.CaseDetails = new CaseDetails();
            returnContainer.CaseDetails.CaseId = row["CaseId"].ToString();
            returnContainer.CaseDetails.Title = row["Title"].ToString();
            returnContainer.CaseDetails.RequestDetails = row["RequestDetails"].ToString();
            int tempInt = 0;
            int.TryParse(row["Budget"].ToString(), out tempInt);
            returnContainer.CaseDetails.Budget = tempInt;
            returnContainer.CaseDetails.AssignedAgentId = row["AssignedAgentId"].ToString();

            // Todo: We can get this in a single join
            if(!string.IsNullOrEmpty(returnContainer.CaseDetails.AssignedAgentId))
            {
                parameters = new Dictionary<string, object>();
                parameters.Add("@agentId", returnContainer.CaseDetails.AssignedAgentId);
                parameters.Add("@caseId", requestContainer.CaseId);
                parameters.Add("@deleted", false);

                 result = sqlProvider.ExecuteQuery(SqlQueries.GetAgentContextualInfoForUserCase, parameters);
                if (result.Tables.Count < 1)
                {
                    throw new ApplicationException("Query failed");
                }

                if (result.Tables[0].Rows.Count != 1)
                {
                    throw new ApplicationException("Query failed");
                }

                row = result.Tables[0].Rows[0];
                returnContainer.ContextualCaseDetails = new ContextualCaseDetails();
                returnContainer.ContextualCaseDetails.ContextId = row["ContextId"].ToString();
                returnContainer.ContextualCaseDetails.UserId = row["UserId"].ToString();
                returnContainer.ContextualCaseDetails.AgentId = row["AgentId"].ToString();
                returnContainer.ContextualCaseDetails.AgentName = row["AgentName"].ToString();
                returnContainer.ContextualCaseDetails.UserNotes = row["UserNotes"].ToString();
                returnContainer.ContextualCaseDetails.Quote = row["Quote"].ToString();
                returnContainer.ContextualCaseDetails.Timeline = row["Timeline"].ToString();
                returnContainer.ContextualCaseDetails.PaymentStatus = row["PaymentStatus"].ToString();
            }

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}