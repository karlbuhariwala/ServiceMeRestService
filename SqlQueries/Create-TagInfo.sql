CREATE TABLE [dbo].[TagInfo]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Tag] NVARCHAR(63) NOT NULL,
    [AgentIdGroup1] NVARCHAR(4000),
    [AgentIdGroup2] NVARCHAR(4000),
    [Keyword] NVARCHAR(4000),
    [IsEnterpriseTag] BIT NOT NULL,
    [EnterpriseTagRating] REAL,
    EnterpriseTagRatingCount INT,
    EnterpriseTagPositiveRatingCount INT,
    [LocalitySpecificTag] BIT NOT NULL,
    [DateTimeTagCode] DATETIMEOFFSET, 
    [Code] INT,
    [Deleted] BIT NOT NULL,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL, 
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL, 
)

-- DROP TABLE [dbo].[TagInfo]