CREATE TABLE [dbo].[Participant] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Type]     NVARCHAR (MAX)   NULL,
    [Actor]    UNIQUEIDENTIFIER NULL,
    [Required] NVARCHAR (MAX)   NULL,
    [Status]   NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Participant] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Participa__Actor__078C1F06] FOREIGN KEY ([Actor]) REFERENCES [dbo].[Entity] ([Id])
);

