CREATE TABLE [dbo].[UserVerification]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
	[VerificationCode] INT NOT NULL, 
    [TimeStamp] DATETIMEOFFSET NOT NULL, 
    [Deleted] BIT NOT NULL,
)

-- DROP TABLE [dbo].[UserVerification]