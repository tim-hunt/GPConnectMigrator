CREATE TABLE [dbo].[Organization] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [ODSCode]        NVARCHAR (20)    NOT NULL,
    [PeriodStart]    DATETIME         NULL,
    [PeriodEnd]      DATETIME         NULL,
    [Type]           NVARCHAR (50)    NOT NULL,
    [Name]           NVARCHAR (255)   NOT NULL,
    [Telecom]        NVARCHAR (20)    NULL,
    [MainLocationID] UNIQUEIDENTIFIER NULL,
    [AddressID]      UNIQUEIDENTIFIER NULL,
    [PartOfID]       UNIQUEIDENTIFIER NULL,
    [ContactID]      UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address] ([Id]),
    FOREIGN KEY ([ContactID]) REFERENCES [dbo].[Contact] ([Id]),
    FOREIGN KEY ([PartOfID]) REFERENCES [dbo].[Organization] ([Id]),
    CONSTRAINT [FK_Organization_Location] FOREIGN KEY ([MainLocationID]) REFERENCES [dbo].[Location] ([Id])
);

