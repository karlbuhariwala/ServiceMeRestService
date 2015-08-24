// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentContextCaseDetailsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

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

            returnContainer.ContextualCaseDetails = new ContextualCaseDetails()
            {
                AgentName = "Murlat Tardewot",
                Quote = "Rs. 450",
                Timeline = "2 days",
                PaymentStatus = "Paid: 100. Balance: 350",
                UserNotes = "These are test user notes\r\n this is not the next line",
            };

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}