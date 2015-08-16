// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetProfileContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Get profile request container
    /// </summary>
    [DataContract]
    public class GetProfileRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember(Name = "userId")]
        public string UserId { get; set; }
    }

    /// <summary>
    /// Get profile return container
    /// </summary>
    [DataContract]
    public class GetProfileReturnContrainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [DataMember(Name = "userInfo")]
        public UserProfile User { get; set; }
    }
}