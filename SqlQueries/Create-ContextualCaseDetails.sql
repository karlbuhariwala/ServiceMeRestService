CREATE TABLE [dbo].[ContextualCaseDetails]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL,
    [ContextId] UNIQUEIDENTIFIER NOT NULL,
    [CaseId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [AgentId] UNIQUEIDENTIFIER NOT NULL,
    [Quote] INT,
    [Timeline] NVARCHAR(1023),
    [PaymentStatus] NVARCHAR(1023),
    [UserNotes] NVARCHAR(4000),
    [AgentNotes] NVARCHAR(4000),
    [NewMessage] BIT,
    [Blocked] BIT NOT NULL,
    [Deleted] BIT NOT NULL,
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL,
)

-- DROP TABLE [dbo].[ContextualCaseDetails]