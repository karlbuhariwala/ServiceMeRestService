// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentCaseDetailsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Get agent case details request container
    /// </summary>
    [DataContract]
    public class GetAgentCaseDetailsRequestContainer : BaseRequestContainer
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
    /// Get agent case details return container
    /// </summary>
    [DataContract]
    public class GetAgentCaseDetailsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the case information.
        /// </summary>
        /// <value>
        /// The case information.
        /// </value>
        [DataMember(Name = "caseInfo")]
        public CaseDetails CaseInfo { get; set; }

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