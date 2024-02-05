CREATE TABLE [dbo].[Contact] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Title]      NVARCHAR (50)    NULL,
    [GivenName]  NVARCHAR (100)   NOT NULL,
    [MiddleName] NVARCHAR (100)   NULL,
    [Surname]    NVARCHAR (100)   NOT NULL,
    [AddressID]  UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address] ([Id])
);

