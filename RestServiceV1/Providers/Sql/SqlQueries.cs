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
        public const string CheckIfPhoneNumberRegisteredQuery = @"SELECT
    UserId
FROM
    UserInfo
WHERE
    PhoneNumber = @phoneNumber";

        /// <summary>
        /// The create new profile query
        /// </summary>
        public const string CreateNewProfileQuery = @"INSERT INTO
    UserInfo
    (
        UserId
        , PhoneNumber
        , IsVerified
        , [IsAgent]
        , [IsManager]
        , Deleted
        , [DateTimeCreated]
        , [DateTimeUpdated]
    )
VALUES
    (
        @userId
        , @phoneNumber
        , @isVerified
        , @isAgent
        , @isManager
        , @deleted
        , @dateTimeCreated
        , @dateTimeUpdated
    )";

        /// <summary>
        /// The get user profile query
        /// </summary>
        public const string GetUserProfileQuery = "GetUserProfileQuery";

        /// <summary>
        /// The insert device verification code
        /// </summary>
        public const string InsertDeviceVerificationCode = @"INSERT INTO
    UserVerification
    (
        UserId
        , VerificationCode
        , [TimeStamp]
        , Deleted
    )
VALUES
    (
        @userId
        , @VerificationCode
        , @TimeStamp
        , @Deleted
    )";

        /// <summary>
        /// The retrieve device verification code
        /// </summary>
        public const string RetrieveDeviceVerificationCode = "RetrieveDeviceVerificationCode";
    }
}