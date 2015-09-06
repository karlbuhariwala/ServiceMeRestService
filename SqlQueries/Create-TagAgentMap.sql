CREATE TABLE [dbo].[TagAgentMap]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Tag] NVARCHAR(63) NOT NULL,
    [AgentIdGroup1] NVARCHAR(4000),
    [AgentIdGroup2] NVARCHAR(4000),
    [Deleted] BIT NOT NULL,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL, 
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL, 
)

-- DROP TABLE [dbo].[TagKeywordMap]