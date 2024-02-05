CREATE TABLE [dbo].[Composition] (
    [Id]                         UNIQUEIDENTIFIER NOT NULL,
    [Identifier]                 UNIQUEIDENTIFIER NULL,
    [CrossCareSettingIdentifier] UNIQUEIDENTIFIER NULL,
    [Status]                     NVARCHAR (MAX)   NULL,
    [Type]                       NVARCHAR (MAX)   NULL,
    [Class]                      NVARCHAR (MAX)   NULL,
    [Subject]                    UNIQUEIDENTIFIER NULL,
    [Encounter]                  UNIQUEIDENTIFIER NULL,
    [Author]                     UNIQUEIDENTIFIER NULL,
    [Observation]                NVARCHAR (MAX)   NULL,
    [Problem]                    NVARCHAR (MAX)   NULL,
    [Title]                      NVARCHAR (MAX)   NULL,
    [Code]                       NVARCHAR (MAX)   NULL,
    [OrderedByCode]              NVARCHAR (MAX)   NULL,
    [CareSettingType]            NVARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Compositio_Encounter] FOREIGN KEY ([Encounter]) REFERENCES [dbo].[Encounter] ([Id]),
    CONSTRAINT [FK_Compositio_Identifier] FOREIGN KEY ([Identifier]) REFERENCES [dbo].[Identifier] ([Id]),
    CONSTRAINT [FK_Compositio_Patient] FOREIGN KEY ([Subject]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK_Compositio_Practicioner] FOREIGN KEY ([Author]) REFERENCES [dbo].[Practicioner] ([Id])
);

