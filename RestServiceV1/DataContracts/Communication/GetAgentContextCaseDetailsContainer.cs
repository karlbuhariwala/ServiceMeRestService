// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentContextCaseDetailsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Get agent context case details request container
    /// </summary>
    [DataContract]
    public class GetAgentContextCaseDetailsRequestContainer : BaseRequestContainer
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
        /// Gets or sets the agent identifier.
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        [DataMember(Name = "agentId")]
        public string AgentId { get; set; }
    }

    /// <summary>
    /// Get agent context case details return container
    /// </summary>
    [DataContract]
    public class GetAgentContextCaseDetailsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the contextual case details.
        /// </summary>
        /// <value>
        /// The contextual case details.
        /// </value>
        [DataMember(Name = "contextualCaseDetails")]
        public ContextualCaseDetails ContextualCaseDetails { get; set; }
    }
}