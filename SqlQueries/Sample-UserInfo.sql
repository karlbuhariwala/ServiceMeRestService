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