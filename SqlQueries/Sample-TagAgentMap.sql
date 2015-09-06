INSERT INTO
	[TagAgentMap]
	(
		[Tag]
		, [AgentIdGroup1]
		, [AgentIdGroup2]
		, [Deleted]
		, [DateTimeCreated]
		, [DateTimeUpdated]
	)
VALUES
	(
		'DJ'
		, 'be3136e5-556b-4da5-977f-bb192f7829bf|$|0cec65b7-29d0-4923-9757-87dfdf0a776f|$|200d46c5-f889-4a50-a645-36270b113ba2'
		, ''
		, 0
		, CURRENT_TIMESTAMP
		, CURRENT_TIMESTAMP
	)

SELECT
	Top 10
	*
FROM
	TagAgentMap
ORDER BY
	Id desc

SELECT
	AgentIdGroup1
	, AgentIdGroup2
FROM
	TagAgentMap
WHERE
	Tag in ('DJ', 'PartyPlanning')