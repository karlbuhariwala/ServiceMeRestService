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
	Name = COALESCE('Testname1', Name)
	, ContactPref = COALESCE('contact pref', Name)
	, EmailAddress = COALESCE(NULL, Name)
	, [Address] = COALESCE('Toots place', Name)
WHERE
	UserId = '8D126288-81BD-4EE4-BF61-0930CEB551C6'