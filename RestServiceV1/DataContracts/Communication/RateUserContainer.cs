// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = RateUserContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Rate user request container
    /// </summary>
    [DataContract]
    public class RateUserRequestContainer : BaseRequestContainer
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
        /// Gets or sets a value indicating whether this instance is agent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is agent; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isAgent")]
        public bool IsAgent { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [DataMember(Name = "rating")]
        public double Rating { get; set; }
    }

    /// <summary>
    /// Rate user return container
    /// </summary>
    [DataContract]
    public class RateUserReturnContainer : BaseReturnContainer
    {
    }
}