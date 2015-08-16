// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SqlQueries.cs

namespace RestServiceV1.Providers
{
    /// <summary>
    /// Sql queries to run
    /// </summary>
    public static class SqlQueries
    {
        /// <summary>
        /// The check if phone number registered query
        /// </summary>
        public const string CheckIfPhoneNumberRegisteredQuery = "CheckIfPhoneNumberRegisteredQuery";

        /// <summary>
        /// The create new profile query
        /// </summary>
        public const string CreateNewProfileQuery = "CreateNewProfileQuery";

        /// <summary>
        /// The get user profile query
        /// </summary>
        public const string GetUserProfileQuery = "GetUserProfileQuery";

        /// <summary>
        /// The insert device verification code
        /// </summary>
        public const string InsertDeviceVerificationCode = "InsertDeviceVerificationCode";

        /// <summary>
        /// The retrieve device verification code
        /// </summary>
        public const string RetrieveDeviceVerificationCode = "RetrieveDeviceVerificationCode";
    }
}