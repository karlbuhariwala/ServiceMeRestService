// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetReccomendedAgentsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get reccomended agents request container
    /// </summary>
    [DataContract]
    public class GetRecommendedAgentsRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the case details.
        /// </summary>
        /// <value>
        /// The case details.
        /// </value>
        [DataMember(Name = "caseDetails")]
        public CaseDetails CaseDetails { get; set; }

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
    /// Get reccomended agents return container
    /// </summary>
    [DataContract]
    public class GetRecommendedAgentsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the recommended agents.
        /// </summary>
        /// <value>
        /// The recommended agents.
        /// </value>
        [DataMember(Name = "recommendedAgents")]
        public List<UserProfile> RecommendedAgents { get; set; }
    }
}