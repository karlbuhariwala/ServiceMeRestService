// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = PhoneVerificationProvider.cs

namespace RestServiceV1.Providers
{
    /// <summary>
    /// Phone verfication design provider class
    /// </summary>
    public class PhoneVerificationDesignProvider : IPhoneVerificationProvider
    {
        /// <summary>
        /// Sends the verification SMS.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="verificationCode">The verification code.</param>
        void IPhoneVerificationProvider.SendVerificationSMS(string phone, string verificationCode)
        {
            // Do nothing
        }
    }
}