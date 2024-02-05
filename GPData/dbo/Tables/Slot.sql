CREATE TABLE [dbo].[Slot] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [DeliveryChannel] NVARCHAR (100)   NULL,
    [IdentifierId]    UNIQUEIDENTIFIER NULL,
    [ServiceType]     NVARCHAR (100)   NULL,
    [Speciality]      NVARCHAR (100)   NULL,
    [ScheduleId]      UNIQUEIDENTIFIER NULL,
    [Status]          NVARCHAR (100)   NULL,
    [Start]           DATETIME         NULL,
    [End]             DATETIME         NULL,
    [Overbooked]      BIT              NULL,
    [Comment]         NVARCHAR (255)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdentifierId]) REFERENCES [dbo].[Identifier] ([Id]),
    FOREIGN KEY ([ScheduleId]) REFERENCES [dbo].[Schedule] ([Id])
);

