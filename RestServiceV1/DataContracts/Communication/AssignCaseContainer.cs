// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AssignCaseContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Assigned case request container
    /// </summary>
    [DataContract]
    public class AssignCaseRequestContainer : BaseRequestContainer
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
        [DataMember(Name = "agentId")]
        public string AgentId { get; set; }
    }

    /// <summary>
    /// Assigned case return container
    /// </summary>
    [DataContract]
    public class AssignCaseReturnContainer : BaseReturnContainer
    {
    }
}