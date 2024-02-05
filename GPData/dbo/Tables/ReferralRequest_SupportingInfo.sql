CREATE TABLE [dbo].[ReferralRequest_SupportingInfo] (
    [Entity]          UNIQUEIDENTIFIER NOT NULL,
    [ReferralRequest] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_ReferralRequest_SupportingInfo_Entity] FOREIGN KEY ([Entity]) REFERENCES [dbo].[Entity] ([Id]),
    CONSTRAINT [FK_ReferralRequest_SupportingInfo_ReferralRequest] FOREIGN KEY ([ReferralRequest]) REFERENCES [dbo].[ReferralRequest] ([Id])
);

