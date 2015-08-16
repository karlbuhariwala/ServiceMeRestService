// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentsForAutoCompleteContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Get agents for autocomplete request container
    /// </summary>
    [DataContract]
    public class GetAgentsForAutoCompleteRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [DataMember(Name="text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Get agents for autocomplete return container
    /// </summary>
    [DataContract]
    public class GetAgentsForAutoCompleteReturnContainer : BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the agents.
        /// </summary>
        /// <value>
        /// The agents.
        /// </value>
        [DataMember(Name="agents")]
        public List<UserProfile> Agents { get; set; }
    }
}