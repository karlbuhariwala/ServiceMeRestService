// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddAgentTagsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Add agent tags command class
    /// </summary>
    public class AddAgentTagsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            AddAgentTagsRequestContainer requestContainer = context.InParam as AddAgentTagsRequestContainer;
            AddAgentTagsReturnContainer returnContainer = new AddAgentTagsReturnContainer();

            // Todo: Duplicate tags
            returnContainer.TagsThatNeedCodes = new List<string>()
            {
                "Test3",
                "Test2",
            };

            if (requestContainer.TagCodeList.Where(x => x.Second == 1234).Count() > 0)
            {
                returnContainer.ReturnCode = ReturnCodes.C101;
            }
            else
            {
                returnContainer.ReturnCode = ReturnCodes.C102;
            }

            return returnContainer;
        }
    }
}