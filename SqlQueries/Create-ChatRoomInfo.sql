CREATE TABLE [dbo].[ChatRoomInfo]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL,
    [ChatId] UNIQUEIDENTIFIER NOT NULL,
    [CaseId] UNIQUEIDENTIFIER NOT NULL,
    [ParticipantsAgents] NVARCHAR(4000),
    [ParticipantsUsers] NVARCHAR(4000),
    [Deleted] BIT NOT NULL,
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL,
)

-- DROP TABLE [dbo].[ChatRoomInfo]