--INSERT INTO
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
	UserInfo
ORDER BY
	Id desc

-- Select by phone number
SELECT
	UserId
FROM
	UserInfo
WHERE
	PhoneNumber = '+12156457839'
	AND Deleted = 'FALSE'

-- Update profile
UPDATE 
	UserInfo
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
	UserInfo
WHERE
	UserId IN ('63C184E8-C428-426C-ADE2-31D05515CA28')

-- Find agents for autocomplete
