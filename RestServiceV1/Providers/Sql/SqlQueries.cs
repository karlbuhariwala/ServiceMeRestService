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
    PhoneNumber = @phoneNumber
    AND Deleted = @deleted";

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
        public const string GetUserProfileQuery = @"SELECT
    Name
    , PhoneNumber
    , IsVerified
    , ContactPref
    , EmailAddress
    , [Address]
    , IsAgent
    , IsManager
    , LandingPage
    , PushNotificationsUri
    , Rating
    , NumberOfRatings
    , Tags
    , AreaOfService
    , FavoriteAgents
FROM
    UserInfo
WHERE
    UserId = @userId
    AND Deleted = @deleted";

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
        public const string RetrieveDeviceVerificationCode = @"SELECT
    VerificationCode
    , [TimeStamp]
FROM
    UserVerification
WHERE
    UserId = @userId
    AND Deleted = @deleted";

        /// <summary>
        /// The delete verification entry
        /// </summary>
        public const string DeleteVerificationEntry = @"DELETE FROM UserVerification
WHERE
    UserId = @userId";

        /// <summary>
        /// The update user profile
        /// </summary>
        public const string UpdateUserProfile = @"UPDATE 
    UserInfo
SET
    Name = COALESCE(@UserInfoName, Name)
    , ContactPref = COALESCE(@UserInfoContactPref, ContactPref)
    , EmailAddress = COALESCE(@UserInfoEmailAddress, EmailAddress)
    , [Address] = COALESCE(@UserInfoAddress, [Address])
WHERE
    UserId = @userId";

        /// <summary>
        /// The get column size information
        /// </summary>
        public const string GetColumnSizeInfo = @"SELECT
    '@' + TABLE_NAME + COLUMN_NAME AS [Field]
    , CHARACTER_MAXIMUM_LENGTH AS [Length]
FROM
    INFORMATION_SCHEMA.COLUMNS
WHERE 
    DATA_TYPE = @fieldType";

        public const string GetTagKeywordMap = @"SELECT 
    Tag
    , Keyword
FROM 
    [TagKeywordMap]
WHERE
    Deleted = @deleted";
    }
}