// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddAgentTagsContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Add agent tags request container
    /// </summary>
    [DataContract]
    public class AddAgentTagsRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the tag code list.
        /// </summary>
        /// <value>
        /// The tag code list.
        /// </value>
        [DataMember(Name = "tagCodeList")]
        public List<MyKeyValuePair<string, int>> TagCodeList { get; set; }
    }

    /// <summary>
    /// Add agent tags return container
    /// </summary>
    [DataContract]
    public class AddAgentTagsReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the tag with incorrect code.
        /// </summary>
        /// <value>
        /// The tag with incorrect code.
        /// </value>
        [DataMember(Name = "tagWithIncorrectCode")]
        public string TagWithIncorrectCode { get; set; }

        /// <summary>
        /// Gets or sets the tags that need codes.
        /// </summary>
        /// <value>
        /// The tags that need codes.
        /// </value>
        [DataMember(Name = "tagsThatNeedCodes")]
        public List<string> TagsThatNeedCodes { get; set; }
    }
}