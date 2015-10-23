// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SendChatMessageContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Send chat message request container
    /// </summary>
    [DataContract]
    public class SendChatMessageRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the case identifier.
        /// </summary>
        /// <value>
        /// The case identifier.
        /// </value>
        [DataMember(Name = "caseId")]
        public string CaseId { get; set; }

        /// <summary>
        /// Gets or sets the sender identifier.
        /// </summary>
        /// <value>
        /// The sender identifier.
        /// </value>
        [DataMember(Name = "senderId")]
        public string SenderId { get; set; }

        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        /// <value>
        /// The name of the sender.
        /// </value>
        [DataMember(Name = "senderName")]
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        /// <value>
        /// The type of message.
        /// </value>
        [DataMember(Name = "typeOfMessage")]
        public int TypeOfMessage { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the participants information.
        /// </summary>
        /// <value>
        /// The participants information.
        /// </value>
        [DataMember(Name = "participantsInfo")]
        public List<MyKeyValuePair<string, string>> ParticipantsInfo { get; set; }

    }

    /// <summary>
    /// Send chat message return container
    /// </summary>
    [DataContract]
    public class SendChatMessageReturnContainer : BaseReturnContainer
    {
    }
}