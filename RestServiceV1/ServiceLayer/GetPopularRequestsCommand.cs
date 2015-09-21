// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddAgentTagsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class GetPopularRequestsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetPopularRequestsRequestContainer requestContainer = context.InParam as GetPopularRequestsRequestContainer;
            GetPopularRequestsReturnContainer returnContainer = new GetPopularRequestsReturnContainer();

            returnContainer.Requests = new List<string>()
            {
                "I need someone to do my laundry",
                "I would like to hire a DJ who plays rock music for my birthday party",
                "Need to reserve a table at UTC restaurant",
                "Looking for an interior designer to redesign my living room",
            };

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}