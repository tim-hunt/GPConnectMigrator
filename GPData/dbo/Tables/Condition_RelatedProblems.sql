CREATE TABLE [dbo].[Condition_RelatedProblems] (
    [ConditionId] UNIQUEIDENTIFIER NOT NULL,
    [EntityId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Condition_RelatedProblems_Condition] FOREIGN KEY ([ConditionId]) REFERENCES [dbo].[Condition] ([Id]),
    CONSTRAINT [FK_Condition_RelatedProblems_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Entity] ([Id])
);

