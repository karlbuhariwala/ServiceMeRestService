CREATE TABLE [dbo].[UserInfo]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [PhoneNumber] NVARCHAR(63) NOT NULL, 
    [Name] NVARCHAR(1023),
    [IsVerified] BIT NOT NULL,
    [ContactPref] NVARCHAR(1023),
    [EmailAddress] NVARCHAR(1023),
    [Address] NVARCHAR(2047),
    [PaymentDetails] NVARCHAR(4000),
    [IsAgent] BIT NOT NULL,
    [IsManager] BIT NOT NULL,
    [LandingPage] INT,
    [PushNotificationsUri] NVARCHAR(4000),
    [Rating] REAL,
    [NumberOfRatings] INT,
    [Tags] NVARCHAR(4000),
    [AreaOfService] NVARCHAR(4000),
    [FavoriteAgents] NVARCHAR(4000),
    [Deleted] BIT NOT NULL,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL, 
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL, 
)

-- DROP TABLE [dbo].[UserInfo]