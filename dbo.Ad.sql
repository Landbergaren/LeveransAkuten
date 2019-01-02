CREATE TABLE [dbo].[Ad] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Header]      NCHAR (50)     NULL,
    [Description] NCHAR (1000)   NULL,
    [StartDate]   DATETIME       NOT NULL,
    [EndDate]     DATETIME       NULL,
    [ARequired]   BIT            DEFAULT ((0)) NULL,
    [BRequired]   BIT            DEFAULT ((0)) NULL,
    [CRequired]   BIT            DEFAULT ((0)) NULL,
    [DRequired]   BIT            DEFAULT ((0)) NULL,
    [CERequired]  BIT            DEFAULT ((0)) NULL,
    [UserId]      NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

