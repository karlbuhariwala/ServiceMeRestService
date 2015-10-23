// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GcmContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Gcm container
    /// </summary>
    [DataContract]
    public class GcmContainer
    {
        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        [DataMember(Name = "to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [DataMember(Name = "data")]
        public DataClass Data { get; set; }
    }

    /// <summary>
    /// Data class
    /// </summary>
    [DataContract]
    public class DataClass
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the case identifier.
        /// </summary>
        /// <value>
        /// The case identifier.
        /// </value>
        [DataMember(Name = "caseId")]
        public string CaseId { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        /// <value>
        /// The type of message.
        /// </value>
        [DataMember(Name = "typeOfMessage")]
        public int TypeOfMessage { get; set; }

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
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        [DataMember(Name = "messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the registration ids.
        /// </summary>
        /// <value>
        /// The registration ids.
        /// </value>
        [DataMember(Name = "registration_ids")]
        public List<string> RegistrationIds { get; set; }
    }
}