CREATE TABLE [dbo].[Practicioner_Address] (
    [PracticionerId] UNIQUEIDENTIFIER NOT NULL,
    [AddressId]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Practicioner_Address_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Practicioner_Address_Practicioner] FOREIGN KEY ([PracticionerId]) REFERENCES [dbo].[Practicioner] ([Id])
);

