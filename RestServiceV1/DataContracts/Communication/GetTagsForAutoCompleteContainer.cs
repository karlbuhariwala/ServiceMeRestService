// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetTagsForAutoCompleteContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get tags for autocomplete request container
    /// </summary>
    [DataContract]
    public class GetTagsForAutoCompleteRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Get tags for autocomplete return container
    /// </summary>
    [DataContract]
    public class GetTagsForAutoCompleteReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the suggested tags.
        /// </summary>
        /// <value>
        /// The suggested tags.
        /// </value>
        [DataMember(Name = "suggestedTags")]
        public List<string> SuggestedTags { get; set; }
    }
}