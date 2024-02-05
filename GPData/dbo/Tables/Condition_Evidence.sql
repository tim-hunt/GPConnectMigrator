CREATE TABLE [dbo].[Condition_Evidence] (
    [ConditionId] UNIQUEIDENTIFIER NOT NULL,
    [EntityId]    UNIQUEIDENTIFIER NOT NULL,
    [Code]        NCHAR (100)      NULL,
    CONSTRAINT [FK_Condition_Evidence_Condition] FOREIGN KEY ([ConditionId]) REFERENCES [dbo].[Condition] ([Id]),
    CONSTRAINT [FK_Condition_Evidence_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Entity] ([Id])
);

