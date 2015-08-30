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