// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = InfoBipContainers.cs

namespace RestServiceV1.DataContracts.InApp
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Info Bip's single text message container
    /// </summary>
    [DataContract]
    public class InfoBipSingleTextContainer
    {
        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        [DataMember(Name = "from")]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        [DataMember(Name = "to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}