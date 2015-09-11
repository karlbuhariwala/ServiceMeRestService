// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentCaseDetailsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

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

            returnContainer.CaseInfo = new CaseDetails()
            {
                CaseId = Guid.NewGuid().ToString(),
                Title = "I want to get flowers delivered",
                RequestDetails = "Please could you deliver flowers to my friend. It is his birthday.",
                Budget = 400,
                ContactPreference = new List<string>()
                {
                    "Chat",
                },
            };

            returnContainer.ContextualCaseDetails = new ContextualCaseDetails()
            {
                ContextId = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                AgentId = Guid.NewGuid().ToString(),
                AgentNotes = "This customer is awesome",
                Quote = "200",
                Timeline = "2 hours",
                PaymentStatus = "Not paid",
            };

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}