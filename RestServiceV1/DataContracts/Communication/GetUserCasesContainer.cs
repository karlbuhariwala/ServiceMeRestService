// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetUserCasesRequestContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get user cases request container
    /// </summary>
    [DataContract]
    public class GetUserCasesRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember(Name = "userId")]
        public string UserId { get; set; }
    }

    /// <summary>
    /// Get user cases return container
    /// </summary>
    [DataContract]
    public class GetUserCasesReturnContainer : BaseReturnContainer
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