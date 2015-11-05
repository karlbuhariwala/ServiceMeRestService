--INSERT INTO
    [ContextualCaseDetails]
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
    [ContextualCaseDetails]
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
    [ContextualCaseDetails]
WHERE
    UserId = 'F7CAE2D5-A625-4CDA-A9A1-8F57926867A0'
    AND Deleted = 'FALSE'

-- Update profile
UPDATE 
    [ContextualCaseDetails]
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
	AND Deleted = @deleted

-- Find agents for autocomplete



DELETE FROM [ContextualCaseDetails]
WHERE Id = 1
