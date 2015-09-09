// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentCasesCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

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

            returnContainer.Cases = new List<CaseDetails>(){
                new CaseDetails()
                {
                    CaseId = Guid.NewGuid().ToString(),
                    Title = "Get me flowers",
                    NewEmail = false,
                    NewMessage = true,
                    NewPhoneCall = true,
                    UserName = "Iyer Thanupatil",
                    LastUpdateDateTime = DateTimeOffset.Now,
                },
                new CaseDetails()
                {
                    CaseId = Guid.NewGuid().ToString(),
                    Title = "Help with a date",
                    NewEmail = false,
                    NewMessage = true,
                    NewPhoneCall = false,
                    AssignedAgentId = Guid.NewGuid().ToString(),
                    UserName = "Karpi Manjunath",
                },
                new CaseDetails()
                {
                    CaseId = Guid.NewGuid().ToString(),
                    Title = "Laundry request",
                    NewEmail = false,
                    NewMessage = true,
                    NewPhoneCall = false,
                    AssignedAgentId = Guid.NewGuid().ToString(),
                    UserName = "Indira Hasnath",
                    AssignedAgentName = "Teller Jacklopt",
                    IsEnterpriseTag = true,
                },
            };

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}