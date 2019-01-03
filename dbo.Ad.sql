CREATE TABLE [dbo].[Ad] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Header]      NCHAR (50)   NOT NULL,
    [Description] NCHAR (1000) NULL,
    [StartDate]   DATETIME     NOT NULL,
    [EndDate]     DATETIME     NULL,
    [ARequired]   BIT          DEFAULT ((0)) NOT NULL,
    [BRequired]   BIT          DEFAULT ((0)) NOT NULL,
    [CRequired]   BIT          DEFAULT ((0)) NOT NULL,
    [DRequired]   BIT          DEFAULT ((0)) NOT NULL,
    [CERequired]  BIT          DEFAULT ((0)) NOT NULL,
    [DriverId]    INT          NULL,
    [CompanyId]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Driver] ([Id]),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id])
);

