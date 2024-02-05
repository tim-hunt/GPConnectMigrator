CREATE TABLE [dbo].[Equipment] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [IdentifierID] NVARCHAR (100)   NULL,
    [TypeID]       NVARCHAR (100)   NULL,
    [Manufacturer] NVARCHAR (100)   NOT NULL,
    [Model]        NVARCHAR (100)   NOT NULL,
    [Version]      NVARCHAR (50)    NOT NULL,
    [OwnerID]      UNIQUEIDENTIFIER NULL,
    [Locations]    NVARCHAR (MAX)   NULL,
    [Name]         NVARCHAR (255)   NOT NULL,
    [Telecom]      NVARCHAR (20)    NULL,
    [AddressID]    UNIQUEIDENTIFIER NULL,
    [PartOfID]     UNIQUEIDENTIFIER NULL,
    [ContactID]    UNIQUEIDENTIFIER NULL,
    [EntityId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__Equipmen__3214EC07B1A029E1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Equipment__Addre__440B1D61] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK__Equipment__Conta__44FF419A] FOREIGN KEY ([ContactID]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK__Equipment__Owner__45F365D3] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[Organization] ([Id]),
    CONSTRAINT [FK__Equipment__PartO__46E78A0C] FOREIGN KEY ([PartOfID]) REFERENCES [dbo].[Organization] ([Id]),
    CONSTRAINT [FK_Equipment_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Entity] ([Id])
);

