// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IGcmProvider.cs

namespace RestServiceV1.Providers
{
    using DataContracts;

    /// <summary>
    /// Interface for Gcm provider
    /// </summary>
    interface IGcmProvider : IProvider
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="notificationId">The notification identifier.</param>
        /// <param name="message">The message.</param>
        void SendMessage(GcmContainer message);
    }
}
