CREATE TABLE [dbo].[Condition_RelatedClinicalConditions] (
    [ConditionId] UNIQUEIDENTIFIER NOT NULL,
    [EntityId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Condition_RelatedClinicalConditions_Condition] FOREIGN KEY ([ConditionId]) REFERENCES [dbo].[Condition] ([Id]),
    CONSTRAINT [FK_Condition_RelatedClinicalConditions_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Entity] ([Id])
);

