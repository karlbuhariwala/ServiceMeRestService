// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetTagsForAutoCompleteCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System.Collections.Generic;

    /// <summary>
    /// Command to get the tags for autocomplete
    /// </summary>
    public class GetTagsForAutoCompleteCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetTagsForAutoCompleteRequestContainer requestContainer = context.InParam as GetTagsForAutoCompleteRequestContainer;
            GetTagsForAutoCompleteReturnContainer returnContainer = new GetTagsForAutoCompleteReturnContainer();

            returnContainer.SuggestedTags = new List<string>()
            {
                "Test1",
                "bTest133333333333333333333333333333355555555555555555555555333",
                "bTest122",
                "Test2",
                "DJ",
                "Test14",
            };

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}