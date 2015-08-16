// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = DeviceValidationCommunicationContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Device validation request container
    /// </summary>
    [DataContract]
    public class DeviceValidationRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the validation code.
        /// </summary>
        /// <value>
        /// The validation code.
        /// </value>
        [DataMember(Name = "validationCode")]
        public int ValidationCode { get; set; }
    }

    /// <summary>
    /// Device validation return container
    /// </summary>
    [DataContract]
    public class DeviceValidationReturnContainer : BaseReturnContainer
    {
    }
}