// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetUserTagsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get user tags request container
    /// </summary>
    [DataContract]
    public class GetUserTagsRequestContainer : BaseRequestContainer
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
    /// Get user tags return container
    /// </summary>
    [DataContract]
    public class GetUserTagsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the area of service.
        /// </summary>
        /// <value>
        /// The area of service.
        /// </value>
        [DataMember(Name = "areaOfService")]
        public double AreaOfService { get; set; }
    }
}