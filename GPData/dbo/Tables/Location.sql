CREATE TABLE [dbo].[Location] (
    [Id]                     UNIQUEIDENTIFIER NOT NULL,
    [ODSSiteCodeID]          NVARCHAR (50)    NULL,
    [Status]                 NVARCHAR (50)    NULL,
    [OperationalStatus]      NVARCHAR (50)    NULL,
    [Name]                   NVARCHAR (255)   NULL,
    [Alias]                  NVARCHAR (255)   NULL,
    [Description]            NVARCHAR (MAX)   NULL,
    [Type]                   NVARCHAR (50)    NULL,
    [Telecom]                NVARCHAR (20)    NULL,
    [AddressID]              UNIQUEIDENTIFIER NULL,
    [PhysicalType]           NVARCHAR (50)    NOT NULL,
    [Longitude]              DECIMAL (9, 6)   NOT NULL,
    [Latitude]               DECIMAL (9, 6)   NOT NULL,
    [Altitude]               DECIMAL (9, 6)   NOT NULL,
    [ManagingOrganizationID] UNIQUEIDENTIFIER NULL,
    [PartOfID]               UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address] ([Id]),
    FOREIGN KEY ([ManagingOrganizationID]) REFERENCES [dbo].[Organization] ([Id]),
    FOREIGN KEY ([PartOfID]) REFERENCES [dbo].[Location] ([Id])
);

