CREATE TABLE [dbo].[MedicationRequest] (
    [Id]                                  UNIQUEIDENTIFIER NOT NULL,
    [NumberOfRepeatPrescriptionsAllowed]  INT              NULL,
    [NumberOfRepeatPrescriptionsIssued]   INT              NULL,
    [PrescriptionTypeCode]                NVARCHAR (MAX)   NULL,
    [PrescriptionTypeDisplay]             NVARCHAR (MAX)   NULL,
    [CrossCareIdentifier]                 NVARCHAR (MAX)   NULL,
    [GroupIdentifier]                     NVARCHAR (MAX)   NULL,
    [Status]                              NVARCHAR (MAX)   NULL,
    [Intent]                              NVARCHAR (MAX)   NULL,
    [MedicationId]                        UNIQUEIDENTIFIER NULL,
    [PatientGuid]                         UNIQUEIDENTIFIER NULL,
    [AuthoredOnUTC]                       DATETIME         NULL,
    [RecorderGuid]                        UNIQUEIDENTIFIER NULL,
    [DosageInstructionText]               NVARCHAR (MAX)   NULL,
    [DosageInstructionPatientInstruction] NVARCHAR (MAX)   NULL,
    [MedicationDispenseRequestId]         UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MedicationDispenseRequestId]) REFERENCES [dbo].[MedicationDispenseRequest] ([Id]),
    FOREIGN KEY ([MedicationId]) REFERENCES [dbo].[Medication] ([Id]),
    FOREIGN KEY ([PatientGuid]) REFERENCES [dbo].[Patient] ([Id]),
    FOREIGN KEY ([RecorderGuid]) REFERENCES [dbo].[Practicioner] ([Id])
);

