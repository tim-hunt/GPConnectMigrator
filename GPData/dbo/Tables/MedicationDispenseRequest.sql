CREATE TABLE [dbo].[MedicationDispenseRequest] (
    [Id]                          UNIQUEIDENTIFIER NOT NULL,
    [ValidityPeriodStart]         DATETIME         NULL,
    [ValidityPeriodEnd]           DATETIME         NULL,
    [Quantity]                    DECIMAL (18, 2)  NULL,
    [ExpectedSupplyDurationValue] DECIMAL (18, 2)  NULL,
    [ExpectedSupplyDurationUnit]  DECIMAL (18, 2)  NULL,
    [ExpectedSupplyDurationCode]  DECIMAL (18, 2)  NULL,
    [PerformerGuid]               UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PerformerGuid]) REFERENCES [dbo].[Practicioner] ([Id])
);

