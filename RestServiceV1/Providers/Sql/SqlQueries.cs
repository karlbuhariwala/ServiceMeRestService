// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SqlQueries.cs

using java.lang;
using RestServiceV1.DataContracts.InApp;
using System.Collections.Generic;
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
    , AgentRating
    , AgentRatingCount
    , UserRating
    , UserRatingCount
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
    , [IsAgent] = COALESCE(@IsAgent, [IsAgent])
    , [IsManager] = COALESCE(@IsManager, [IsManager])
    , [Longitude] = COALESCE(@Longitude, [Longitude])
    , [Latitude] = COALESCE(@Latitude, [Latitude])
    , [AreaOfService] = COALESCE(@AreaOfService, [AreaOfService])
    , [AreaOfServiceTopLeftLat] = COALESCE(@AreaOfServiceTopLeftLat, [AreaOfServiceTopLeftLat])
    , [AreaOfServiceTopLeftLng] = COALESCE(@AreaOfServiceTopLeftLng, [AreaOfServiceTopLeftLng])
    , [AreaOfServiceBottomRightLat] = COALESCE(@AreaOfServiceBottomRightLat, [AreaOfServiceBottomRightLat])
    , [AreaOfServiceBottomRightLng] = COALESCE(@AreaOfServiceBottomRightLng, [AreaOfServiceBottomRightLng])
    , [LandingPage] = COALESCE(@LandingPage, [LandingPage])
    , [Tags] = COALESCE(@Tags, [Tags])
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

        /// <summary>
        /// The get tag keyword map
        /// </summary>
        public const string GetTagKeywordMap = @"SELECT 
    Tag
    , Keyword
FROM 
    [TagInfo]
WHERE
    Deleted = @deleted";

        /// <summary>
        /// The update notification token for user
        /// </summary>
        public const string UpdateNotificationTokenForUser = @"UPDATE 
    UserInfo
SET
    PushNotificationsUri = COALESCE(@notificationToken, ContactPref)
WHERE
    UserId = @userId";

        /// <summary>
        /// The create new case
        /// </summary>
        public const string CreateNewCase = @"INSERT INTO
    [CaseInfo]
    (
        CaseId
        , UserId
        , UserName
        , Title
        , ContactPref
        , Tags
        , RequestDetails
        , Budget
        , Address
        , AnotherAddress
        , IsEnterpriseTag
        , Deleted
        , [DateTimeCreated]
        , [DateTimeUpdated]
    )
VALUES
    (
        @caseId
        , @userId
        , @userName
        , @title
        , @contactPref
        , @tags
        , @requestDetails
        , @budget
        , @address
        , @anotherAddress
        , @isEnterpriseTag
        , @deleted
        , @dateTimeCreated
        , @dateTimeUpdated
    )";

        /// <summary>
        /// The add to agent case map
        /// </summary>
        public const string AddToAgentCaseMap = @"INSERT INTO
    [AgentCaseMap]
    (
        CaseId
        , AgentId
        , Blocked
        , Deleted
        , [DateTimeCreated]
        , [DateTimeUpdated]
    )
VALUES
    (
        @caseId
        , @agentId
        , @blocked
        , @deleted
        , @dateTimeCreated
        , @dateTimeUpdated
    )";

        /// <summary>
        /// The add to tag case map
        /// </summary>
        public const string AddToTagCaseMap = @"INSERT INTO
    [TagCaseMap]
    (
        CaseId
        , Tag
        , Closed
        , Deleted
        , [DateTimeCreated]
        , [DateTimeUpdated]
    )
VALUES
    (
        @caseId
        , @tag
        , @closed
        , @deleted
        , @dateTimeCreated
        , @dateTimeUpdated
    )";

        /// <summary>
        /// The get user cases query
        /// </summary>
        public const string GetUserCasesQuery = @"SELECT
    CaseInfo.CaseId
    , CaseInfo.Title
    , CaseInfo.NewMessage
    , CaseInfo.AssignedAgentId
    , AgentInfo.Name
    , CaseInfo.DateTimeUpdated
FROM
    [CaseInfo] AS CaseInfo 
    LEFT JOIN UserInfo AS AgentInfo ON AgentInfo.UserId = CaseInfo.AssignedAgentId
WHERE
    CaseInfo.UserId = @userId
    AND CaseInfo.Deleted = @deleted";

        /// <summary>
        /// The get user case details query
        /// </summary>
        public const string GetUserCaseDetailsQuery = @"SELECT
    CaseId
    , Title
    , RequestDetails
    , Budget
    , AssignedAgentId
FROM
    [CaseInfo]
WHERE
    CaseId = @caseId
    AND Deleted = @deleted";

        /// <summary>
        /// The get agent contextual information for user case
        /// </summary>
        public const string GetAgentContextualInfoForUserCase = @"SELECT
    ContextualCaseDetails.ContextId
    , ContextualCaseDetails.UserId
    , ContextualCaseDetails.AgentId
    , AgentInfo.Name AS AgentName
    , ContextualCaseDetails.UserNotes
    , ContextualCaseDetails.Quote
    , ContextualCaseDetails.Timeline
    , ContextualCaseDetails.PaymentStatus
FROM
    [ContextualCaseDetails] AS ContextualCaseDetails
    LEFT JOIN UserInfo AS AgentInfo ON ContextualCaseDetails.UserId = AgentInfo.UserId
    LEFT JOIN CaseInfo AS CaseInfo ON ContextualCaseDetails.CaseId = CaseInfo.CaseId
WHERE
    ContextualCaseDetails.CaseId = @caseId
    AND ContextualCaseDetails.AgentId = @agentId
    AND ContextualCaseDetails.Deleted = @deleted";

        /// <summary>
        /// The get agents for user case
        /// </summary>
        public const string GetAgentsForUserCase = @"SELECT
    AgentCaseMap.AgentId
    , UserInfo.Name
    , UserInfo.AgentRating
    , UserInfo.AgentRatingCount
FROM
    [AgentCaseMap] AS AgentCaseMap 
    LEFT JOIN [UserInfo] AS UserInfo ON AgentCaseMap.AgentId = UserInfo.UserId
WHERE
    AgentCaseMap.CaseId = @caseId
    AND AgentCaseMap.Deleted = @deleted
    AND AgentCaseMap.Blocked = @blocked";

        /// <summary>
        /// The get cases assigned to agent query
        /// </summary>
        public const string GetAgentCaseDetails = @"SELECT
    CaseInfo.CaseId
    , CaseInfo.Title
    , CaseInfo.RequestDetails
    , CaseInfo.Budget
    , CaseInfo.ContactPref
    , CaseInfo.IsEnterpriseTag
    , ContextualCaseDetails.ContextId
    , ContextualCaseDetails.UserId
    , ContextualCaseDetails.AgentId
    , ContextualCaseDetails.AgentNotes
    , ContextualCaseDetails.Quote
    , ContextualCaseDetails.Timeline
    , ContextualCaseDetails.PaymentStatus
FROM
    [CaseInfo] as CaseInfo
    LEFT JOIN ContextualCaseDetails AS ContextualCaseDetails ON CaseInfo.CaseId = ContextualCaseDetails.CaseId
WHERE
    CaseInfo.CaseId = @caseId
    AND ContextualCaseDetails.AgentId = @agentId
    AND ContextualCaseDetails.Deleted = @deleted
    AND CaseInfo.Deleted = @deleted";

        /// <summary>
        /// The get agent cases
        /// </summary>
        public const string GetAgentCases = @"SELECT
    ContextualCaseDetails.CaseId
    , ContextualCaseDetails.NewMessage
    , ContextualCaseDetails.DateTimeUpdated
    , CaseInfo.Title
    , CaseInfo.AssignedAgentId
    , CaseInfo.AssignedAgentName
    , CaseInfo.IsEnterpriseTag
    , CaseInfo.UserName
FROM
    ContextualCaseDetails as ContextualCaseDetails
    LEFT JOIN CaseInfo as CaseInfo ON ContextualCaseDetails.CaseId = CaseInfo.CaseId
WHERE
    AgentId = @agentId
    AND ContextualCaseDetails.Deleted = @deleted";

        /// <summary>
        /// The insert case context details
        /// </summary>
        public const string InsertCaseContextDetails = @"INSERT INTO
    [ContextualCaseDetails]
    (
        ContextId
        , CaseId
        , UserId
        , AgentId
        , Blocked
        , Deleted
        , [DateTimeCreated]
        , [DateTimeUpdated]
    )
VALUES
    (
        @contextId
        , @caseId
        , @userId
        , @agentId
        , @blocked
        , @deleted
        , @dateTimeCreated
        , @dateTimeUpdated
    )";

        /// <summary>
        /// The assign case to agent
        /// </summary>
        public const string AssignCaseToAgent = @"UPDATE 
    [CaseInfo]
SET
    AssignedAgentId = COALESCE(@assignedAgentId, AssignedAgentId)
WHERE
    CaseId = @caseId";

        /// <summary>
        /// The get chat room details
        /// </summary>
        public const string GetChatRoomDetails = @"SELECT
    ParticipantsAgents
    , ParticipantsUsers
    , ChatId
    , CaseId
FROM
    ChatRoomInfo
WHERE
    CaseId = @caseId";

        /// <summary>
        /// The insert chat room details
        /// </summary>
        public const string InsertChatRoomDetails = @"INSERT INTO
    [ChatRoomInfo]
    (
        CaseId
        , ChatId
        , ParticipantsAgents
        , ParticipantsUsers
        , Deleted
        , [DateTimeCreated]
        , [DateTimeUpdated]
    )
VALUES
    (
        @caseId
        , @chatId
        , @agents
        , @users
        , @deleted
        , @dateTimeCreated
        , @dateTimeUpdated
    )";

        /// <summary>
        /// The update tag with information
        /// </summary>
        public const string UpdateTagWithInfo = @"UPDATE
    TagInfo
SET
    AgentIdGroup1 = COALESCE(@userIds, AgentIdGroup1)
WHERE
    Tag = @tag";

        /// <summary>
        /// The get tags for automatic complete
        /// </summary>
        public const string GetTagsForAutoComplete = @"SELECT
    Tag
FROM
    TagInfo
WHERE
    Tag LIKE @tag";

        /// <summary>
        /// The get agent for automatic complete
        /// </summary>
        public const string GetAgentForAutoComplete = @"SELECT
    Name
    , UserId
    , PhoneNumber
    , AgentRating
    , AgentRatingCount
FROM
    UserInfo
WHERE
    Name LIKE @name
    AND IsAgent = 1
    AND Deleted = 0";

        /// <summary>
        /// The get tag information for adding new tag to agent
        /// </summary>
        private const string GetTagInfoForAddingNewTagToAgent = @"SELECT
    Tag
    , IsEnterpriseTag
    , DateTimeTagCode
    , Code
    , AgentIdGroup1
FROM
    TagInfo
WHERE
    Tag in ({0})
    AND Deleted = @deleted";

        /// <summary>
        /// The get agents by ids
        /// </summary>
        private const string GetUsersByIds = @"SELECT
    UserId
    , Name
    , AgentRating
    , AgentRatingCount
    , AgentPositiveRatingCount
    , AreaOfService
    , Tags
    , FavoriteAgents
    , PushNotificationsUri
FROM
    UserInfo
WHERE
    UserId IN ({0})
    {1}";

        /// <summary>
        /// The get agents for tag
        /// </summary>
        private const string GetAgentsForTag = @"SELECT
    AgentIdGroup1
    , AgentIdGroup2
FROM
    TagInfo
WHERE
    Tag in ({0})";

        /// <summary>
        /// The get user ratings from contextual information
        /// </summary>
        private const string GetUserRatingsFromContextualInfo = @"SELECT
    UserInfo.{0}Rating AS Rating
    , UserInfo.{0}RatingCount AS UserInfoTableRatingCount
    , ContextCaseInfo.{0}RatingCount AS ContextualDetailsRatingCount
FROM
    ContextualCaseDetails AS ContextCaseInfo
    LEFT JOIN UserInfo AS UserInfo ON UserInfo.UserId = ContextCaseInfo.{0}Id
WHERE
    ContextCaseInfo.{0}Id = @userId
    AND ContextCaseInfo.CaseId = @caseId
    AND ContextCaseInfo.deleted = @deleted";

        /// <summary>
        /// The update user information with rating
        /// </summary>
        private const string UpdateUserInfoWithRating = @"UPDATE 
    UserInfo
SET
    {0}Rating = COALESCE(@rating, {0}Rating)
    , {0}RatingCount = COALESCE(@ratingCount, {0}RatingCount)
WHERE
    UserId = @userId";

        private const string UpdateContextualDetailsWithRating = @"UPDATE 
    ContextualCaseDetails
SET
    {0}Rating = COALESCE(@rating, {0}Rating)
    , {0}RatingCount = COALESCE(@ratingCount, {0}RatingCount)
WHERE
    {0}Id = @userId
    AND CaseId = @caseId";

        /// <summary>
        /// Updates the user information with rating query.
        /// </summary>
        /// <param name="isAgent">if set to <c>true</c> [is agent].</param>
        /// <returns>Update contextual details with rating</returns>
        public static string UpdateContextualDetailsWithRatingQuery(bool isAgent)
        {
            string userString = "User";
            if (isAgent)
            {
                userString = "Agent";
            }

            return string.Format(SqlQueries.UpdateContextualDetailsWithRating, userString);
        }

        /// <summary>
        /// Updates the user information with rating query.
        /// </summary>
        /// <param name="isAgent">if set to <c>true</c> [is agent].</param>
        /// <returns>Update agent rating query</returns>
        public static string UpdateUserInfoWithRatingQuery(bool isAgent)
        {
            string userString = "User";
            if (isAgent)
            {
                userString = "Agent";
            }

            return string.Format(SqlQueries.UpdateUserInfoWithRating, userString);
        }

        /// <summary>
        /// Gets the user ratings from contextual information query.
        /// </summary>
        /// <param name="isAgent">if set to <c>true</c> [is agent].</param>
        /// <returns></returns>
        public static string GetUserRatingsFromContextualInfoQuery(bool isAgent)
        {
            string userString = "User";
            if(isAgent)
            {
                userString = "Agent";
            }

            return string.Format(SqlQueries.GetUserRatingsFromContextualInfo, userString);
        }

        /// <summary>
        /// Gets the agents for tag query.
        /// </summary>
        /// <param name="tags">The tags.</param>
        /// <returns>Query with correct length of tags</returns>
        public static string GetAgentsForTagQuery(List<string> tags)
        {
            List<string> parameterNames = new List<string>();
            for (int i = 0; i < tags.Count; i++)
            {
                parameterNames.Add("@tag" + i);
            }

            return string.Format(SqlQueries.GetAgentsForTag, string.Join(",", parameterNames));
        }

        /// <summary>
        /// Gets the agents by ids query.
        /// </summary>
        /// <param name="userIds">The user ids.</param>
        /// <returns>Query with correct length of userIds</returns>
        public static string GetUsersByIdsQuery(List<string> userIds, Coordinates coordinates = null)
        {
            List<string> parameterNames = new List<string>();
            for (int i = 0; i < userIds.Count; i++)
            {
                parameterNames.Add("@userId" + i);
            }

            string latLngString = string.Empty;
            if(coordinates != null)
            {
                latLngString = string.Format(@"AND (AreaOfServiceBottomRightLat < {0} AND {0} < AreaOfServiceTopLeftLat)", "@Lat");
                latLngString += string.Format(@"AND (AreaOfServiceTopLeftLng < {0} AND {0} < AreaOfServiceBottomRightLng)", "@Lng");
            }

            return string.Format(SqlQueries.GetUsersByIds, string.Join(",", parameterNames), latLngString);
        }

        /// <summary>
        /// Gets the tag information for adding new tag to agent query.
        /// </summary>
        /// <param name="tags">The tags.</param>
        /// <returns></returns>
        public static string GetTagInfoForAddingNewTagToAgentQuery(List<string> tags)
        {
            List<string> parameterNames = new List<string>();
            for (int i = 0; i < tags.Count; i++)
            {
                parameterNames.Add("@tag" + i);
            }

            return string.Format(SqlQueries.GetTagInfoForAddingNewTagToAgent, string.Join(",", parameterNames));
        }
    }
}