CREATE TABLE [dbo].[ReferralRequest_ReasonReference] (
    [Entity]          UNIQUEIDENTIFIER NOT NULL,
    [ReferralRequest] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_ReferralRequest_ReasonReference_Entity] FOREIGN KEY ([Entity]) REFERENCES [dbo].[Entity] ([Id]),
    CONSTRAINT [FK_ReferralRequest_ReasonReference_ReferralRequest] FOREIGN KEY ([ReferralRequest]) REFERENCES [dbo].[ReferralRequest] ([Id])
);

