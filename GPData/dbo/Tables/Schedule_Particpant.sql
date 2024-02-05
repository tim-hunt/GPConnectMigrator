CREATE TABLE [dbo].[Schedule_Particpant] (
    [ScheduleId]    UNIQUEIDENTIFIER NOT NULL,
    [ParticipantId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Schedule_Particpant_Participant] FOREIGN KEY ([ParticipantId]) REFERENCES [dbo].[Participant] ([Id]),
    CONSTRAINT [FK_Schedule_Particpant_Schedule] FOREIGN KEY ([ScheduleId]) REFERENCES [dbo].[Schedule] ([Id])
);

