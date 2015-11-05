// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AssignAgentToCaseCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Assign agent to case command
    /// </summary>
    public class AssignAgentToCaseCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        /// Result of the OnExecute
        /// </returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            AssignCaseRequestContainer requestContainer = context.InParam as AssignCaseRequestContainer;
            AssignCaseReturnContainer returnContainer = new AssignCaseReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@assignedAgentId", requestContainer.AgentId);
            parameters.Add("@caseId", requestContainer.CaseId);

            sqlProvider.ExecuteQuery(SqlQueries.AssignCaseToAgent, parameters);

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}