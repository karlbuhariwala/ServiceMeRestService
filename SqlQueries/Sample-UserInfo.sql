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
		'be3136e5-556b-4da5-977f-bb192f7829bf'
		, '+12156457839'
		, 0
		, 1
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
    Name = COALESCE('Karl-Agent', Name)
	, Rating = 4.5
	, NumberOfRatings = 1234
	, Tags = 'DJ|$|MedicalSupplier'
	, AreaOfService = 'Colaba'
WHERE
	UserId = 'BE3136E5-556B-4DA5-977F-BB192F7829BF'
	
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

DELETE FROM UserInfo
WHERE
	UserId LIKE '%'
