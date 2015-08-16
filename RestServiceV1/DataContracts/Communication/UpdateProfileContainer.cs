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
    }
}