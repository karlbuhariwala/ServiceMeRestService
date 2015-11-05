--INSERT INTO
    [AgentCaseMap]
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
        '8d126288-81bd-4ee4-bf61-0930ceb551c6'
        , '+12156457839'
        , 0
        , 0
        , 0
        , 0
        , CURRENT_TIMESTAMP
        , CURRENT_TIMESTAMP
    )

-- Select top 10
SELECT 
    TOP 10
    *
FROM
    [AgentCaseMap]
ORDER BY
    Id desc

-- Select by phone number
SELECT
    AgentCaseMap.AgentId
    , UserInfo.Name
    , UserInfo.Rating
    , UserInfo.NumberOfRatings
FROM
    [AgentCaseMap] AS AgentCaseMap 
    LEFT JOIN [UserInfo] AS UserInfo ON AgentCaseMap.AgentId = UserInfo.UserId
WHERE
    AgentCaseMap.CaseId = @caseId
    AND AgentCaseMap.Deleted = @deleted
    AND AgentCaseMap.Blocked = @blocked

-- Update profile
UPDATE 
    [AgentCaseMap]
SET
    Name = COALESCE(@UserInfoName, Name)
    , ContactPref = COALESCE(@UserInfoContactPref, ContactPref)
    , EmailAddress = COALESCE(@UserInfoEmailAddress, EmailAddress)
    , [Address] = COALESCE(@UserInfoAddress, [Address])
    , [IsAgent] = COALESCE(@IsAgent, [IsAgent])
    , [IsManager] = COALESCE(@UserInfoAddress, [IsManager])
    , [LandingPage] = COALESCE(@UserInfoAddress, [LandingPage])
WHERE
    UserId = '8D126288-81BD-4EE4-BF61-0930CEB551C6'

-- Find agents
SELECT
    UserId
    , Name
    , Rating
    , NumberOfRatings
    , AreaOfService
    , Tags
    , FavoriteAgents
FROM
    [AgentCaseMap]
WHERE
    UserId IN ('63C184E8-C428-426C-ADE2-31D05515CA28')

-- Find agents for autocomplete

DELETE FROM AgentCaseMap WHERE Id LIKE '%'
