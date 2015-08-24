// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetUserCaseDetailCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;

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

            returnContainer.CaseDetails = new CaseDetails()
            {
                CaseId = Guid.NewGuid().ToString(),
                Title = "Get me some chocolate to eat",
                RequestDetails = "I would like to eat some cake from this bakery down at patia lane. Can you come deliver it to me?",
                Budget = 450,
            };

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}