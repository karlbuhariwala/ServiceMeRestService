INSERT INTO
	TagInfo
	(
		[Tag]
		, [AgentIdGroup1]
		, [AgentIdGroup2]
		, [Keyword]
		, [IsEnterpriseTag]
		, [DateTimeTagCode]
		, Code
		, [Deleted]
		, [DateTimeCreated]
		, [DateTimeUpdated]
	)
VALUES
	(
		'Cleaners'
		, ''
		, ''
		, 'clean|$|cleaning|$|cleaners|$|cleaner|$|house|$|tiles|$|scrubbing|$|kitchen|$|'
		, 0
		, NULL
		, NULL
		, 0
		, CURRENT_TIMESTAMP
		, CURRENT_TIMESTAMP
	)

SELECT
	Top 10
	*
FROM
	TagInfo
ORDER BY
	Id desc

SELECT
	Tag
	, IsEnterpriseTag
	, DateTimeTagCode
	, Code
FROM
	TagInfo
WHERE
	Tag in ('DJ', 'PartyPlanning')
	AND Deleted = @deleted

DECLARE @tag varchar
SET @tag = '%Lau%'

SELECT
	Tag
FROM
	TagInfo
WHERE
	Tag LIKE @tag