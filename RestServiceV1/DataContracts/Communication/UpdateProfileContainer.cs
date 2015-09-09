// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = UpdateProfileContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Update profile request container
    /// </summary>
    [DataContract]
    public class UpdateProfileRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>
        /// The user profile.
        /// </value>
        [DataMember(Name = "userProfile")]
        public UserProfile UserProfile { get; set; }
    }

    /// <summary>
    /// Update profile return container
    /// </summary>
    [DataContract]
    public class UpdateProfileReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is agent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is agent; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isAgent")]
        public bool IsAgent { get; set; }
    }
}