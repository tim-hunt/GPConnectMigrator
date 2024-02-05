CREATE TABLE [dbo].[Address] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [Use]                 NVARCHAR (255)   NULL,
    [HouseNameFlatNumber] NVARCHAR (255)   NULL,
    [NumberAndStreet]     NVARCHAR (255)   NULL,
    [Village]             NVARCHAR (255)   NULL,
    [Town]                NVARCHAR (255)   NULL,
    [County]              NVARCHAR (255)   NULL,
    [Postcode]            NVARCHAR (20)    NULL,
    [From]                DATETIME         NULL,
    [To]                  DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

