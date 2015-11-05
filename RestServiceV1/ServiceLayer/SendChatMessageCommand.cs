// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddAgentTagsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using Providers;
    using System;

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

            IGcmProvider gcmProvider = (IGcmProvider)ProviderFactory.Instance.CreateProvider<IGcmProvider>(null);

            foreach (var item in requestContainer.ParticipantsInfo)
            {
                if (!item.First.Equals(requestContainer.SenderId, StringComparison.OrdinalIgnoreCase))
                {
                    GcmContainer gcmContainer = new GcmContainer();
                    gcmContainer.To = item.Second;
                    gcmContainer.Data = new DataClass();
                    gcmContainer.Data.CaseId = requestContainer.CaseId;
                    gcmContainer.Data.SenderId = requestContainer.SenderId;
                    gcmContainer.Data.TypeOfMessage = requestContainer.TypeOfMessage;
                    gcmContainer.Data.SenderName = requestContainer.SenderName;
                    gcmContainer.Data.Message = requestContainer.Message;
                    gcmContainer.Data.RegistrationIds = new System.Collections.Generic.List<string>();

                    gcmProvider.SendMessage(gcmContainer);
                }
            }

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}