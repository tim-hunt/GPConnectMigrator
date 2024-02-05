CREATE TABLE [dbo].[ReferralRequest_Replaces] (
    [ReplacingReferralRequestId] UNIQUEIDENTIFIER NOT NULL,
    [ReferralRequestId]          UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_ReferralRequest_Replaces_ReferralRequest] FOREIGN KEY ([ReplacingReferralRequestId]) REFERENCES [dbo].[ReferralRequest] ([Id]),
    CONSTRAINT [FK_ReferralRequest_Replaces_ReferralRequest1] FOREIGN KEY ([ReferralRequestId]) REFERENCES [dbo].[ReferralRequest] ([Id])
);

