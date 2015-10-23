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

    /// <summary>
    /// Send chat message command
    /// </summary>
    public class SendChatMessageCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            SendChatMessageRequestContainer requestContainer = context.InParam as SendChatMessageRequestContainer;
            SendChatMessageReturnContainer returnContainer = new SendChatMessageReturnContainer();

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}