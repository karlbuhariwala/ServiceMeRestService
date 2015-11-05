CREATE TABLE [dbo].[CaseInfo]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL,
    [DateTimeResolved] DATETIMEOFFSET,
    [DateTimeClosed] DATETIMEOFFSET,
    [CaseId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [UserName] NVARCHAR(1023),
    [Title] NVARCHAR(1023),
    [ContactPref] NVARCHAR(1023),
    [Tags] NVARCHAR(4000),
    [RequestDetails] NVARCHAR(4000),
    [Budget] INT,
    [Address] NVARCHAR(2047),
    [AnotherAddress] NVARCHAR(2047),
    [NewMessage] BIT,
    [AssignedAgentId] UNIQUEIDENTIFIER,
    [AssignedAgentName] NVARCHAR(1023),
    [IsEnterpriseTag] BIT,
    [IsMetadataComplete] BIT,
    [Deleted] BIT NOT NULL,
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL, 
)

-- DROP TABLE [dbo].[CaseInfo]