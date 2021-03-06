﻿CREATE TABLE [dbo].[UserInfo]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [OrgId] UNIQUEIDENTIFIER NOT NULL,
    [PhoneNumber] NVARCHAR(63) NOT NULL, 
    [Name] NVARCHAR(1023),
    [IsVerified] BIT NOT NULL,
    [ContactPref] NVARCHAR(1023),
    [EmailAddress] NVARCHAR(1023),
    [Address] NVARCHAR(2047),
    [Latitude] REAL,
    [Longitude] REAL,
    AreaOfService REAL,
    AreaOfServiceTopLeftLat REAL,
    AreaOfServiceTopLeftLng REAL,
    AreaOfServiceBottomRightLat REAL,
    AreaOfServiceBottomRightLng REAL,
    [PaymentDetails] NVARCHAR(4000),
    [IsAgent] BIT NOT NULL,
    [IsManager] BIT NOT NULL,
    [LandingPage] INT,
    [PushNotificationsUri] NVARCHAR(4000),
    [AgentRating] REAL,
    [UserRating] REAL,
    UserRatingCount INT,
    AgentRatingCount INT,
    AgentPositiveRatingCount INT,
    [Tags] NVARCHAR(4000),
    [FavoriteAgents] NVARCHAR(4000),
    [Deleted] BIT NOT NULL,
    [DateTimeCreated] DATETIMEOFFSET NOT NULL, 
    [DateTimeUpdated] DATETIMEOFFSET NOT NULL, 
)

-- DROP TABLE [dbo].[UserInfo]