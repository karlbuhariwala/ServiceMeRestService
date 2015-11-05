// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentCaseDetailsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;

    public class GetAgentCaseDetailsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentCaseDetailsRequestContainer requestContainer = context.InParam as GetAgentCaseDetailsRequestContainer;
            GetAgentCaseDetailsReturnContainer returnContainer = new GetAgentCaseDetailsReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@deleted", false);
            parameters.Add("@caseId", requestContainer.CaseId);
            parameters.Add("@agentId", requestContainer.AgentId);

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetAgentCaseDetails, parameters);

            if(result.Tables.Count < 1 && result.Tables[0].Rows.Count != 1)
            {
                throw new ApplicationException("Query error");
            }

            DataRow row = result.Tables[0].Rows[0];

            returnContainer.CaseInfo = new CaseDetails();
            returnContainer.CaseInfo.CaseId = row["CaseId"].ToString();
            returnContainer.CaseInfo.Title = row["Title"].ToString();
            returnContainer.CaseInfo.RequestDetails = row["RequestDetails"].ToString();

            int tempInt = 0;
            int.TryParse(row["Budget"].ToString(), out tempInt);
            returnContainer.CaseInfo.Budget = tempInt;

            returnContainer.CaseInfo.ContactPreference = row["ContactPref"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList();

            returnContainer.ContextualCaseDetails = new ContextualCaseDetails();
            returnContainer.ContextualCaseDetails.ContextId = row["ContextId"].ToString();
            returnContainer.ContextualCaseDetails.UserId = row["UserId"].ToString();
            returnContainer.ContextualCaseDetails.AgentId = row["AgentId"].ToString();
            returnContainer.ContextualCaseDetails.AgentNotes = row["AgentNotes"].ToString();
            returnContainer.ContextualCaseDetails.Timeline = row["Timeline"].ToString();
            returnContainer.ContextualCaseDetails.PaymentStatus = row["PaymentStatus"].ToString();
            returnContainer.ContextualCaseDetails.Quote = row["Quote"].ToString();

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}