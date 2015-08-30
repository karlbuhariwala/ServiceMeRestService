// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = BaseContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Base request container
    /// </summary>
    [DataContract]
    public class BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the name of the provider.
        /// </summary>
        /// <value>
        /// The name of the provider.
        /// </value>
        [DataMember(Name = "providerName")]
        public string ProviderName { get; set; }
    }

    /// <summary>
    /// Base return container
    /// </summary>
    [DataContract]
    public class BaseReturnContainer
    {
        /// <summary>
        /// Gets or sets the return code.
        /// </summary>
        /// <value>
        /// The return code.
        /// </value>
        [DataMember(Name = "returnCode")]
        public string ReturnCode { get; set; }
    }
}