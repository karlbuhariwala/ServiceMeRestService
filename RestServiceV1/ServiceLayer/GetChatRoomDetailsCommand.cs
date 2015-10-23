// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetChatRoomDetailsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Get chat room details command
    /// </summary>
    public class GetChatRoomDetailsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetChatRoomDetailsRequestContainer requestContainer = context.InParam as GetChatRoomDetailsRequestContainer;
            GetChatRoomDetailsReturnContainer returnContainer = new GetChatRoomDetailsReturnContainer();

            returnContainer.CaseId = requestContainer.CaseId;
            returnContainer.ParticipantsInfo = new List<MyKeyValuePair<string, string>>();
            returnContainer.ParticipantsInfo.Add(new MyKeyValuePair<string, string>("Android", "Test connection info"));

            returnContainer.UserIdNamePairs = new List<MyKeyValuePair<string, string>>();
            returnContainer.UserIdNamePairs.Add(new MyKeyValuePair<string, string>(Guid.NewGuid().ToString(), "Kevin Termur"));
            returnContainer.UserIdNamePairs.Add(new MyKeyValuePair<string, string>(Guid.NewGuid().ToString(), "Hasting Implante"));

            returnContainer.ChatRoomTitle = "Kevin, Hasting";
            returnContainer.UserType = 0;

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}