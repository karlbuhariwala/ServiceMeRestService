// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SaveNewCaseContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Save new case request container
    /// </summary>
    [DataContract]
    public class SaveNewCaseRequestContainer : BaseRequestContainer
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
        /// Gets or sets the agent ids.
        /// </summary>
        /// <value>
        /// The agent ids.
        /// </value>
        [DataMember(Name = "agentIds")]
        public List<string> AgentIds { get; set; }
    }

    /// <summary>
    /// Save new case return container
    /// </summary>
    [DataContract]
    public class SaveNewCaseReturnContainer : BaseReturnContainer
    {
    }
}