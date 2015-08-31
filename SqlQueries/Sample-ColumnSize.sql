﻿SELECT
	'@' + TABLE_NAME + COLUMN_NAME AS [Field]
	, CHARACTER_MAXIMUM_LENGTH AS [Length]
FROM
	INFORMATION_SCHEMA.COLUMNS
WHERE 
	DATA_TYPE = 'nvarchar'