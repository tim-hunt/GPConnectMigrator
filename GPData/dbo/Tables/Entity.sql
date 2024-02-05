CREATE TABLE [dbo].[Entity] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [EntityType] INT              NOT NULL,
    CONSTRAINT [PK_Entity] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Entity_EntityType] FOREIGN KEY ([EntityType]) REFERENCES [dbo].[EntityType] ([EntityType])
);

