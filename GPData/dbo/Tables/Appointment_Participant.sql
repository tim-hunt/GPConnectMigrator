CREATE TABLE [dbo].[Appointment_Participant] (
    [AppointmentId] UNIQUEIDENTIFIER NOT NULL,
    [ParticipantId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Appointment_Participant_Appointment] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointment] ([Id]),
    CONSTRAINT [FK_Appointment_Participant_Participant] FOREIGN KEY ([ParticipantId]) REFERENCES [dbo].[Participant] ([Id])
);

