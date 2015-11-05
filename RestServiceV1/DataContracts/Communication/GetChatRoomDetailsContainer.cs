// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetChatRoomDetailsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get chat room details request container
    /// </summary>
    [DataContract]
    public class GetChatRoomDetailsRequestContainer : BaseRequestContainer
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
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the agent identifier.
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        [DataMember(Name = "agentId")]
        public string AgentId { get; set; }
    }

    /// <summary>
    /// Get chat room details return container
    /// </summary>
    [DataContract]
    public class GetChatRoomDetailsReturnContainer : BaseReturnContainer
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
        /// Gets or sets the chat identifier.
        /// </summary>
        /// <value>
        /// The chat identifier.
        /// </value>
        [DataMember(Name = "chatId")]
        public string ChatId { get; set; }

        /// <summary>
        /// Gets or sets the participants information.
        /// </summary>
        /// <value>
        /// The participants information.
        /// </value>
        [DataMember(Name = "participantsInfo")]
        public List<MyKeyValuePair<string, string>> ParticipantsInfo { get; set; }

        /// <summary>
        /// Gets or sets the user identifier name pairs.
        /// </summary>
        /// <value>
        /// The user identifier name pairs.
        /// </value>
        [DataMember(Name = "userIdNamePairs")]
        public List<MyKeyValuePair<string, string>> UserIdNamePairs { get; set; }

        /// <summary>
        /// Gets or sets the chat room title.
        /// </summary>
        /// <value>
        /// The chat room title.
        /// </value>
        [DataMember(Name = "chatRoomTitle")]
        public string ChatRoomTitle { get; set; }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>
        /// The type of the user.
        /// </value>
        [DataMember(Name = "userType")]
        public int UserType { get; set; }
    }
}