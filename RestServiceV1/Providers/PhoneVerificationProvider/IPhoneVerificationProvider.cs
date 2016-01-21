// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IPhoneVerificationProvider.cs

namespace RestServiceV1.Providers
{
    /// <summary>
    /// Interface phone verification provider
    /// </summary>
    interface IPhoneVerificationProvider : IProvider
    {
        /// <summary>
        /// Sends the verification SMS.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="verificationCode">The verification code.</param>
        void SendVerificationSMS(string phone, string verificationCode);
    }
}
