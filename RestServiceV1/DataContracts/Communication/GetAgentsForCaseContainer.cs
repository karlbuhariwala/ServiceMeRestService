// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentsForCaseContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get agents for case request container
    /// </summary>
    [DataContract]
    public class GetAgentsForCaseRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the case identifier.
        /// </summary>
        /// <value>
        /// The case identifier.
        /// </value>
        [DataMember(Name = "caseId")]
        public string CaseId { get; set; }
    }

    /// <summary>
    /// Get agents for case return container
    /// </summary>
    [DataContract]
    public class GetAgentsForCaseReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the agents.
        /// </summary>
        /// <value>
        /// The agents.
        /// </value>
        [DataMember(Name = "agents")]
        public List<UserProfile> Agents { get; set; }
    }
}