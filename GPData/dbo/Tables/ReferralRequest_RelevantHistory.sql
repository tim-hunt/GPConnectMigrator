CREATE TABLE [dbo].[ReferralRequest_RelevantHistory] (
    [Entity]          UNIQUEIDENTIFIER NOT NULL,
    [ReferralRequest] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_ReferralRequest_RelevantHistory_Entity] FOREIGN KEY ([Entity]) REFERENCES [dbo].[Entity] ([Id]),
    CONSTRAINT [FK_ReferralRequest_RelevantHistory_ReferralRequest] FOREIGN KEY ([ReferralRequest]) REFERENCES [dbo].[ReferralRequest] ([Id])
);

