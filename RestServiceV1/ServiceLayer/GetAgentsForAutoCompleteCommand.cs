// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentsForAutoCompleteCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Command to get the agents for autocomplete
    /// </summary>
    public class GetAgentsForAutoCompleteCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetAgentsForAutoCompleteRequestContainer requestContainer = context.InParam as GetAgentsForAutoCompleteRequestContainer;
            GetAgentsForAutoCompleteReturnContainer returnContainer = new GetAgentsForAutoCompleteReturnContainer();

            returnContainer.ReturnCode = ReturnCodes.C101;

            returnContainer.Agents = new List<UserProfile>()
            {
                new UserProfile()
                {
                    Name = "Karl Potter",
                    UserId = Guid.NewGuid().ToString(),
                    PhoneNumber = "+9145683948398",
                    Rating = 2.3,
                    NumberOfRatings = 134,
                },
                new UserProfile()
                {
                    Name = "Karan Polopkar",
                    UserId = Guid.NewGuid().ToString(),
                    PhoneNumber = "+545448131564",
                    Rating = 3,
                    NumberOfRatings = 64,
                },
                new UserProfile()
                {
                    Name = "Kari Bubanjart",
                    UserId = Guid.NewGuid().ToString(),
                    PhoneNumber = "+54464168",
                    Rating = 1.2,
                    NumberOfRatings = 11,
                },
                new UserProfile()
                {
                    Name = "Karmeshwar Punawala",
                    UserId = Guid.NewGuid().ToString(),
                    PhoneNumber = "+65464655456",
                    Rating = 4.1,
                    NumberOfRatings = 99,
                },
            };

            return returnContainer;
        }
    }
}