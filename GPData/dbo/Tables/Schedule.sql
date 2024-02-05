CREATE TABLE [dbo].[Schedule] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [PracticionerRole]     NVARCHAR (50)    NULL,
    [ServiceCategory]      NVARCHAR (50)    NULL,
    [Speciality]           NVARCHAR (50)    NULL,
    [PlanningHorizonStart] DATETIME         NULL,
    [PlanningHorizonEnd]   DATETIME         NULL,
    [Comment]              NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED ([Id] ASC)
);

