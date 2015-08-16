// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = CaseOverviewForUserContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Case overview request container
    /// </summary>
    [DataContract]
    public class CaseOverviewForUserRequestContainer : BaseRequestContainer
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
    /// Case overview return container
    /// </summary>
    [DataContract]
    public class CaseOverviewForUserReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the list of case details.
        /// </summary>
        /// <value>
        /// The list of case details.
        /// </value>
        [DataMember(Name = "listOfCaseDetails")]
        public List<CaseDetails> ListOfCaseDetails { get; set; }
    }
}