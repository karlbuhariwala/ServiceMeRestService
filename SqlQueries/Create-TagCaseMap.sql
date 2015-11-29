﻿CREATE TABLE [dbo].[TagCaseMap]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL,
    [CaseId] UNIQUEIDENTIFIER NOT NULL,
    [Tag] NVARCHAR(1023) NOT NULL,
    [Closed] BIT NOT NULL,
    [Deleted] BIT NOT NULL,
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL, 
)

-- DROP TABLE [dbo].[TagCaseMap]