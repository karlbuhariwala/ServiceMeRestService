// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentDetailsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Command to get the agent's details
    /// </summary>
    public class GetAgentDetailsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentDetailsRequestContainer requestContainer = context.InParam as GetAgentDetailsRequestContainer;
            GetAgentDetailsReturnContainer returnContainer = new GetAgentDetailsReturnContainer();

            returnContainer.ReturnCode = ReturnCodes.C101;
            returnContainer.IsFavorite = false;
            returnContainer.AgentProfile = new UserProfile()
            {
                UserId = Guid.NewGuid().ToString(),
                Name = "Benish Guratte",
                Rating = 2.4,
                NumberOfRatings = 54,
                AreaOfService = "India",
                Tags = new List<string>()
                {
                    "Test tag",
                    "Flowers",
                }
            };

            return returnContainer;
        }
    }
}