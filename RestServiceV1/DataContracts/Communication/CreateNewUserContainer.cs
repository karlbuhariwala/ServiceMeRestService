// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = CreateNewUserContainer.cs

namespace RestServiceV1.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Create new user request container
    /// </summary>
    [DataContract]
    public class CreateNewUserRequestContainer : BaseRequestContainer
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the device.
        /// </summary>
        /// <value>
        /// The type of the device.
        /// </value>
        [DataMember(Name = "deviceType")]
        public string DeviceType { get; set; }
    }

    /// <summary>
    /// Create new user return container
    /// </summary>
    [DataContract]
    public class CreateNewUserReturnContainer : BaseReturnContainer
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
    /// Device type
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// The phone
        /// </summary>
        Phone,

        /// <summary>
        /// The computer
        /// </summary>
        Computer,
    }
}