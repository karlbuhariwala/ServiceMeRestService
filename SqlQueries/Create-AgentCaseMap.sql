CREATE TABLE [dbo].[AgentCaseMap]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL,
    [CaseId] UNIQUEIDENTIFIER NOT NULL,
    [AgentId] UNIQUEIDENTIFIER NOT NULL,
    [Blocked] BIT NOT NULL,
    [Deleted] BIT NOT NULL,
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL, 
)

-- DROP TABLE [dbo].[AgentCaseMap]