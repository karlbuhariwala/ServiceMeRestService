// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetTagsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System.Collections.Generic;

    /// <summary>
    /// Get Tags Command
    /// </summary>
    public class GetTagsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetTagsRequestContainer requestContainer = context.InParam as GetTagsRequestContainer;
            GetTagsReturnContainer returnContainer = new GetTagsReturnContainer();

            returnContainer.Tags = new List<string>()
            {
                "Flowers",
                "TagWithAVeryLongNameThatKeepsOnGoingAndGoing",
            };

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}