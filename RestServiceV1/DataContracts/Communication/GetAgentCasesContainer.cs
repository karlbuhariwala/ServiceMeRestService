// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentCasesContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get agent cases request container
    /// </summary>
    [DataContract]
    public class GetAgentCasesRequestContainer : BaseRequestContainer
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
    /// Get agent cases return container
    /// </summary>
    [DataContract]
    public class GetAgentCasesReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the cases.
        /// </summary>
        /// <value>
        /// The cases.
        /// </value>
        [DataMember(Name = "cases")]
        public List<CaseDetails> Cases { get; set; }

    }
}