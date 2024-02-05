﻿CREATE TABLE [dbo].[DiagnosticReport] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Identifier]       UNIQUEIDENTIFIER NULL,
    [Status]           NVARCHAR (50)    NULL,
    [Assigner]         UNIQUEIDENTIFIER NOT NULL,
    [ProcedureRequest] UNIQUEIDENTIFIER NOT NULL,
    [Category]         NVARCHAR (50)    NULL,
    [Code]             NVARCHAR (50)    NULL,
    [Subject]          UNIQUEIDENTIFIER NOT NULL,
    [Encounter]        UNIQUEIDENTIFIER NULL,
    [EffectiveFrom]    DATETIME         NULL,
    [EffectiveTo]      DATETIME         NULL,
    [Issued]           DATETIME         NOT NULL,
    [Performer]        UNIQUEIDENTIFIER NULL,
    [Specimen]         UNIQUEIDENTIFIER NOT NULL,
    [Result]           UNIQUEIDENTIFIER NULL,
    [Conclusion]       NVARCHAR (50)    NULL,
    [CodedDiagnosis]   NVARCHAR (50)    NULL,
    [PresentedFrom]    NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Assigner]) REFERENCES [dbo].[Organization] ([Id]),
    FOREIGN KEY ([Encounter]) REFERENCES [dbo].[Encounter] ([Id]),
    FOREIGN KEY ([Identifier]) REFERENCES [dbo].[Identifier] ([Id]),
    FOREIGN KEY ([Result]) REFERENCES [dbo].[Observation] ([Id]),
    FOREIGN KEY ([Specimen]) REFERENCES [dbo].[Specimen] ([Id]),
    FOREIGN KEY ([Subject]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK__Diagnosti__Perfo__681373AD] FOREIGN KEY ([Performer]) REFERENCES [dbo].[Entity] ([Id]),
    CONSTRAINT [FK_DiagnosticReport_ProcedureRequest] FOREIGN KEY ([ProcedureRequest]) REFERENCES [dbo].[ProcedureRequest] ([Id])
);
