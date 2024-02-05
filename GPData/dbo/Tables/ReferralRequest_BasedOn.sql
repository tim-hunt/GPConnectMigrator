CREATE TABLE [dbo].[ReferralRequest_BasedOn] (
    [EntityId]          UNIQUEIDENTIFIER NOT NULL,
    [ReferralRequestId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_ReferralRequest_BasedOn_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Entity] ([Id]),
    CONSTRAINT [FK_ReferralRequest_BasedOn_ReferralRequest] FOREIGN KEY ([ReferralRequestId]) REFERENCES [dbo].[ReferralRequest] ([Id])
);

