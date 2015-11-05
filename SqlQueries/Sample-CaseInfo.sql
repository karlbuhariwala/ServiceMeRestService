--INSERT INTO
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
    [CaseInfo]
ORDER BY
    Id desc

-- Select by phone number
SELECT
    CaseId
    , Title
    , NewMessage
    , AssignedAgentId
    , AssignedAgentName
    , DateTimeUpdated
FROM
    [CaseInfo]
WHERE
    UserId = 'F7CAE2D5-A625-4CDA-A9A1-8F57926867A0'
    AND Deleted = 'FALSE'

-- Update profile
UPDATE 
    [CaseInfo]
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


UPDATE 
    [CaseInfo]
SET
    AssignedAgentId = COALESCE(@assignedAgentId, Name)
WHERE
    CaseId = @caseId

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
    [CaseInfo]
WHERE
    UserId IN ('63C184E8-C428-426C-ADE2-31D05515CA28')

-- Find agents for autocomplete


SELECT
    CaseInfo.CaseId
    , CaseInfo.Title
    , CaseInfo.RequestDetails
    , CaseInfo.Budget
	, CaseInfo.ContactPref
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
    CaseInfo.CaseId = '3A828D54-711C-46DF-887E-1A310664C81C'
    --AND ContextualCaseDetails.AgentId = @agentId
    AND ContextualCaseDetails.Deleted = 0
    AND CaseInfo.Deleted = 0


DELETE FROM [CaseInfo] WHERE Id LIKE '%'
