// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentContextCaseDetailsCommand.cs

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
    /// Get agent cntext case details command
    /// </summary>
    public class GetAgentContextCaseDetailsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentContextCaseDetailsRequestContainer requestContainer = context.InParam as GetAgentContextCaseDetailsRequestContainer;
            GetAgentContextCaseDetailsReturnContainer returnContainer = new GetAgentContextCaseDetailsReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@caseId", requestContainer.CaseId);
            parameters.Add("@agentId", requestContainer.AgentId);
            parameters.Add("@deleted", false);
            parameters.Add("@blocked", false);

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetAgentContextualInfoForUserCase, parameters);
            if (result.Tables.Count < 1)
            {
                throw new ApplicationException("Query failed");
            }

            if (result.Tables[0].Rows.Count == 0)
            {
                Dictionary<string, object> parametersToInsert = new Dictionary<string, object>();
                parametersToInsert.Add("@dateTimeCreated", DateTimeOffset.UtcNow.ToString());
                parametersToInsert.Add("@contextId", Guid.NewGuid().ToString());
                parametersToInsert.Add("@caseId", requestContainer.CaseId);
                parametersToInsert.Add("@userId", requestContainer.UserId);
                parametersToInsert.Add("@agentId", requestContainer.AgentId);
                parametersToInsert.Add("@deleted", false);
                parametersToInsert.Add("@blocked", false);
                parametersToInsert.Add("@dateTimeUpdated", DateTimeOffset.UtcNow.ToString());

                sqlProvider.ExecuteQuery(SqlQueries.InsertCaseContextDetails, parametersToInsert);

                result = sqlProvider.ExecuteQuery(SqlQueries.GetAgentContextualInfoForUserCase, parameters);
                if (result.Tables.Count < 1 && result.Tables[0].Rows.Count != 1)
                {
                    throw new ApplicationException("Query failed");
                }
            }

            DataRow row = result.Tables[0].Rows[0];
            returnContainer.ContextualCaseDetails = new ContextualCaseDetails();

            returnContainer.ContextualCaseDetails = new ContextualCaseDetails();
            returnContainer.ContextualCaseDetails.ContextId = row["ContextId"].ToString();
            returnContainer.ContextualCaseDetails.UserId = row["UserId"].ToString();
            returnContainer.ContextualCaseDetails.AgentId = row["AgentId"].ToString();
            returnContainer.ContextualCaseDetails.AgentName = row["AgentName"].ToString();
            returnContainer.ContextualCaseDetails.UserNotes = row["UserNotes"].ToString();
            returnContainer.ContextualCaseDetails.Quote = row["Quote"].ToString();
            returnContainer.ContextualCaseDetails.Timeline = row["Timeline"].ToString();
            returnContainer.ContextualCaseDetails.PaymentStatus = row["PaymentStatus"].ToString();            

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}