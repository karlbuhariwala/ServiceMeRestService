// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentsForCaseCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Get agents for case command
    /// </summary>
    public class GetAgentsForCaseCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentsForCaseRequestContainer requestContainer = context.InParam as GetAgentsForCaseRequestContainer;
            GetAgentsForCaseReturnContainer returnContainer = new GetAgentsForCaseReturnContainer();

            returnContainer.ReturnCode = ReturnCodes.C101;
            returnContainer.Agents = new List<UserProfile>()
            {
                new UserProfile()
                {
                    UserId = Guid.NewGuid().ToString(),
                    Name = "Raj Jackmar",
                    Rating = 4.5,
                    NumberOfRatings = 273,
                },
                new UserProfile()
                {
                    UserId = Guid.NewGuid().ToString(),
                    Name = "Peter Thum",
                    Rating = 3.1,
                    NumberOfRatings = 326,
                },
                new UserProfile()
                {
                    UserId = Guid.NewGuid().ToString(),
                    Name = "Sita Gills",
                    Rating = 4.8,
                    NumberOfRatings = 65,
                },
            };

            return returnContainer;
        }
    }
}