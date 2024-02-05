CREATE TABLE [dbo].[Encounter] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Identifier]    NVARCHAR (MAX)   NULL,
    [Status]        NVARCHAR (MAX)   NULL,
    [Type]          NVARCHAR (MAX)   NULL,
    [PatientGuid]   UNIQUEIDENTIFIER NULL,
    [PerformerId]   UNIQUEIDENTIFIER NULL,
    [RecorderId]    UNIQUEIDENTIFIER NULL,
    [PeriodStart]   DATETIME         NULL,
    [PeriodEnd]     DATETIME         NULL,
    [DurationValue] DECIMAL (18, 2)  NULL,
    [DurationUnit]  NVARCHAR (MAX)   NULL,
    [DurationCode]  NVARCHAR (MAX)   NULL,
    [EntityId]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__Encounte__3214EC075BF916E0] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Encounter__Patie__412EB0B6] FOREIGN KEY ([PatientGuid]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK__Encounter__Perfo__4222D4EF] FOREIGN KEY ([PerformerId]) REFERENCES [dbo].[Practicioner] ([Id]),
    CONSTRAINT [FK__Encounter__Recor__4316F928] FOREIGN KEY ([RecorderId]) REFERENCES [dbo].[Practicioner] ([Id]),
    CONSTRAINT [FK_Encounter_Encounter] FOREIGN KEY ([Id]) REFERENCES [dbo].[Encounter] ([Id]),
    CONSTRAINT [FK_Encounter_Encounter1] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Encounter] ([Id])
);

