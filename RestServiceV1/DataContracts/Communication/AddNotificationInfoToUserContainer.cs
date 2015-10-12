// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddNotificationInfoToUserContainer.cs

namespace RestServiceV1.DataContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    /// <summary>
    /// Add notification info to user request container
    /// </summary>
    [DataContract]
    public class AddNotificationInfoToUserRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the notification token.
        /// </summary>
        /// <value>
        /// The notification token.
        /// </value>
        [DataMember(Name = "notificationToken")]
        public string NotificationToken { get; set; }
    }

    /// <summary>
    /// Add notification info to user return container
    /// </summary>
    public class AddNotificationInfoToUserReturnContainer : BaseReturnContainer
    {

    }
}