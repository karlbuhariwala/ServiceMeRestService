// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetUserCaseDetailContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Get user case details request container
    /// </summary>
    [DataContract]
    public class GetUserCaseDetailRequestContainer : BaseRequestContainer
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
    /// Get user case details return container
    /// </summary>
    [DataContract]
    public class GetUserCaseDetailReturnContainer : BaseReturnContainer
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
        /// Gets or sets the contextual case details.
        /// </summary>
        /// <value>
        /// The contextual case details.
        /// </value>
        [DataMember(Name = "contextualCaseDetails")]
        public ContextualCaseDetails ContextualCaseDetails { get; set; }

    }
}