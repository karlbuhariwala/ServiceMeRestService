// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetTagsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get tags request container
    /// </summary>
    [DataContract]
    public class GetTagsRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the case details.
        /// </summary>
        /// <value>
        /// The case details.
        /// </value>
        [DataMember(Name = "caseDetails")]
        public CaseDetails CaseDetails { get; set; }
    }

    /// <summary>
    /// Get tags return container
    /// </summary>
    [DataContract]
    public class GetTagsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }
    }
}