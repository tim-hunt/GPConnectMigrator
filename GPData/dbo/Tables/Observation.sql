CREATE TABLE [dbo].[Observation] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Status]            NVARCHAR (MAX)   NULL,
    [Category]          NVARCHAR (MAX)   NULL,
    [Code]              NVARCHAR (MAX)   NULL,
    [SubjectId]         UNIQUEIDENTIFIER NULL,
    [ContextId]         UNIQUEIDENTIFIER NULL,
    [EffectiveDate]     DATETIME         NULL,
    [EffectiveDateFrom] DATETIME         NULL,
    [EffectiveDateTo]   DATETIME         NULL,
    [Issued]            DATETIME         NULL,
    [PerformerId]       UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PerformerId]) REFERENCES [dbo].[Practicioner] ([Id]),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK__Observati__Conte__534D60F1] FOREIGN KEY ([ContextId]) REFERENCES [dbo].[Encounter] ([Id])
);

