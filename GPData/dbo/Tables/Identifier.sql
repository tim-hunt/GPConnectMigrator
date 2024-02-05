CREATE TABLE [dbo].[Identifier] (
    [Use]         NVARCHAR (250)   NULL,
    [Type]        NVARCHAR (250)   NULL,
    [System]      NVARCHAR (MAX)   NULL,
    [Value]       NVARCHAR (MAX)   NULL,
    [PeriodStart] DATETIME         NULL,
    [PeriodEnd]   DATETIME         NULL,
    [Assigner]    NVARCHAR (250)   NULL,
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Identifier] PRIMARY KEY CLUSTERED ([Id] ASC)
);

