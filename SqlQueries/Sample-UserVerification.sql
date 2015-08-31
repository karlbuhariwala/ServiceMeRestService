--INSERT INTO
	UserVerification
	(
		UserId
		, VerificationCode
		, [TimeStamp]
		, Deleted
	)
VALUES
	(
		'8d126288-81bd-4ee4-bf61-0930ceb551c6'
		, 1234
		, CURRENT_TIMESTAMP
		, 0
	)

-- Select top 10
SELECT 
	TOP 10
	*
FROM
	UserVerification
ORDER BY
	Id desc

-- Get verification
SELECT
	VerificationCode
	, [TimeStamp]
FROM
	UserVerification
WHERE
	UserId = 'E6BB8248-9AC5-4CC5-8FC3-DA70D0943D59'
	AND Deleted = 'FALSE'

-- Delete an entry
DELETE FROM UserVerification
WHERE
	UserId = 'E6BB8248-9AC5-4CC5-8FC3-DA70D0943D59'