// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetPopularRequestsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get popular requests request container
    /// </summary>
    [DataContract]
    public class GetPopularRequestsRequestContainer : BaseRequestContainer
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
    /// Get popular requests return container
    /// </summary>
    [DataContract]
    public class GetPopularRequestsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the requests.
        /// </summary>
        /// <value>
        /// The requests.
        /// </value>
        [DataMember(Name = "requests")]
        public List<string> Requests { get; set; }
    }
}