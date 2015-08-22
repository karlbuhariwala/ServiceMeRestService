// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetUserCasesCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Get user cases command
    /// </summary>
    public class GetUserCasesCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetUserCasesRequestContainer requestContainer = context.InParam as GetUserCasesRequestContainer;
            GetUserCasesReturnContainer returnContainer = new GetUserCasesReturnContainer();

            returnContainer.Cases = new List<CaseDetails>(){
                new CaseDetails()
                {
                    CaseId = Guid.NewGuid().ToString(),
                    Title = "Get me flowers",
                    NewEmail = false,
                    NewMessage = true,
                    NewPhoneCall = true,
                    AssignedAgentId = Guid.NewGuid().ToString(),
                    AssignedAgentName = "Iyer Thanupatil",
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
                    AssignedAgentName = "Karpi Manjunath",
                },
            };

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}