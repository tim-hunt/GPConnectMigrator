CREATE TABLE [dbo].[Medication] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [SnomedCode]           NVARCHAR (MAX)   NULL,
    [MultilexCode]         NVARCHAR (MAX)   NULL,
    [SnomedDisplayName]    NVARCHAR (MAX)   NULL,
    [MultilexDisplayName]  NVARCHAR (MAX)   NULL,
    [MultilexUserSelected] BIT              NULL,
    [ManufacturerId]       UNIQUEIDENTIFIER NULL,
    [Form]                 NVARCHAR (MAX)   NULL,
    [Quantity]             DECIMAL (18, 2)  NULL,
    [BatchNumber]          NVARCHAR (MAX)   NULL,
    [ExpirationDate]       DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Organization] ([Id])
);

