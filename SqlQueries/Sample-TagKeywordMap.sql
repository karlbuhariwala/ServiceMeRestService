INSERT INTO
	[TagKeywordMap]
	(
		Tag
		, keyword
		, Deleted
		, [DateTimeCreated]
		, [DateTimeUpdated]
	)
VALUES
	(
		'PartyPlanning'
		, 'party|$|birthday|$|hire'
		, 0
		, CURRENT_TIMESTAMP
		, CURRENT_TIMESTAMP
	)

-- Select top 10
SELECT 
	TOP 10
	*
FROM
	[TagKeywordMap]
ORDER BY
	Id desc

-- Select non deleted
SELECT 
	Tag
	, Keyword
FROM 
	[TagKeywordMap]
WHERE
	Deleted = 0