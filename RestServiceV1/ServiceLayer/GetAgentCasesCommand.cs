// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentCasesCommand.cs

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
    /// Get agent cases command
    /// </summary>
    public class GetAgentCasesCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentCasesRequestContainer requestContainer = context.InParam as GetAgentCasesRequestContainer;
            GetAgentCasesReturnContainer returnContainer = new GetAgentCasesReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@agentId", requestContainer.AgentId);
            parameters.Add("@deleted", false);

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetAgentCases, parameters);

            if (result.Tables.Count < 1)
            {
                throw new ApplicationException("Query failed");
            }

            returnContainer.Cases = new List<CaseDetails>();
            foreach (DataRow row in result.Tables[0].Rows)
            {
                CaseDetails caseDetails = new CaseDetails();
                caseDetails.CaseId = row["CaseId"].ToString();
                caseDetails.Title = row["Title"].ToString();
                caseDetails.UserName = row["UserName"].ToString();

                bool tempBool = false;
                bool.TryParse(row["NewMessage"].ToString(), out tempBool);
                caseDetails.NewMessage = tempBool;

                tempBool = false;
                bool.TryParse(row["IsEnterpriseTag"].ToString(), out tempBool);
                caseDetails.IsEnterpriseTag = tempBool;

                if (caseDetails.IsEnterpriseTag)
                {
                    string tempString = row["AssignedAgentId"].ToString();
                    if (tempString != DBNull.Value.ToString())
                    {
                        caseDetails.AssignedAgentId = tempString;
                    }
                    else
                    {
                        caseDetails.AssignedAgentId = string.Empty;
                    }

                    tempString = row["AssignedAgentName"].ToString();
                    if (tempString != DBNull.Value.ToString())
                    {
                        caseDetails.AssignedAgentName = tempString;
                    }
                    else
                    {
                        caseDetails.AssignedAgentName = string.Empty;
                    }
                }

                DateTimeOffset tempDateTimeOffset;
                if (DateTimeOffset.TryParse(row["DateTimeUpdated"].ToString(), out tempDateTimeOffset))
                {
                    caseDetails.LastUpdateDateTime = tempDateTimeOffset;
                }
                else
                {
                    // Log an error
                }

                returnContainer.Cases.Add(caseDetails);
            }

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}