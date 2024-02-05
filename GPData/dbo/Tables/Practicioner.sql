CREATE TABLE [dbo].[Practicioner] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Reference]        NVARCHAR (50)    NOT NULL,
    [SdsUserId]        NVARCHAR (50)    NULL,
    [SdsRoleProfileId] NVARCHAR (50)    NULL,
    [Title]            NVARCHAR (20)    NULL,
    [GivenName]        NVARCHAR (100)   NOT NULL,
    [MiddleNames]      NVARCHAR (250)   NULL,
    [Surname]          NVARCHAR (100)   NOT NULL,
    [Gender]           NVARCHAR (10)    NULL,
    [DateOfBirthUtc]   DATETIME         NULL,
    [AddressID]        UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address] ([Id])
);

