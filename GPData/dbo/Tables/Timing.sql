CREATE TABLE [dbo].[Timing] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [Event]              DATETIME2 (7)    NULL,
    [BoundsDuration]     DECIMAL (18, 9)  NULL,
    [BoundsDurationMax]  DECIMAL (18, 9)  NULL,
    [BoundsDurationUnit] NVARCHAR (50)    NULL,
    [Count]              INT              NULL,
    [CountMax]           INT              NULL,
    [Duration]           DECIMAL (18, 9)  NULL,
    [DurationMax]        DECIMAL (18, 9)  NULL,
    [DurationUnit]       NVARCHAR (50)    NULL,
    [Frequency]          INT              NULL,
    [FrequencyMax]       INT              NULL,
    [Period]             DECIMAL (18, 9)  NULL,
    [PeriodMax]          DECIMAL (18, 9)  NULL,
    [PeriodUnit]         NVARCHAR (50)    NULL,
    [DayOfWeek]          NVARCHAR (50)    NULL,
    [TimeOfDay]          INT              NULL,
    [When]               NVARCHAR (50)    NULL,
    [Offset]             INT              NULL,
    [Code]               NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

