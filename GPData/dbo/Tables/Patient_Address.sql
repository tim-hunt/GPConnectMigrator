CREATE TABLE [dbo].[Patient_Address] (
    [PatientId] UNIQUEIDENTIFIER NOT NULL,
    [AddressId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Patient_Address] PRIMARY KEY CLUSTERED ([PatientId] ASC, [AddressId] ASC),
    CONSTRAINT [FK_Patient_Address_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Patient_Address_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([Id])
);

