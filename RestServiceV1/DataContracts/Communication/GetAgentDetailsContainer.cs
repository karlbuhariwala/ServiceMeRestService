// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentDetailsRequestContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Get agent details request container
    /// </summary>
    [DataContract]
    public class GetAgentDetailsRequestContainer : BaseRequestContainer
    {
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
    /// Get agent details return container
    /// </summary>
    [DataContract]
    public class GetAgentDetailsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the agent profile.
        /// </summary>
        /// <value>
        /// The agent profile.
        /// </value>
        [DataMember(Name = "agentProfile")]
        public UserProfile AgentProfile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is favorite.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is favorite; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isFavorite")]
        public bool IsFavorite { get; set; }
    }
}