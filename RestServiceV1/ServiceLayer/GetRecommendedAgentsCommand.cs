// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetRecommendedAgentsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Command to get the reccomended agents for a new case
    /// </summary>
    public class GetRecommendedAgentsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetRecommendedAgentsRequestContainer requestContainer = context.InParam as GetRecommendedAgentsRequestContainer;
            GetRecommendedAgentsReturnContainer returnContainer = new GetRecommendedAgentsReturnContainer();

            returnContainer.ReturnCode = ReturnCodes.C101;
            returnContainer.RecommendedAgents = new List<UserProfile>()
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