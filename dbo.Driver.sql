CREATE TABLE [dbo].[Driver] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (50)  NOT NULL,
    [LastName]      NVARCHAR (50)  NOT NULL,
    [A]             BIT            DEFAULT ((0)) NOT NULL,
    [B]             BIT            DEFAULT ((0)) NOT NULL,
    [C]             BIT            DEFAULT ((0)) NOT NULL,
    [Ce]            BIT            DEFAULT ((0)) NOT NULL,
    [D]             BIT            DEFAULT ((0)) NOT NULL,
    [DateOfBirth]   DATETIME       NOT NULL,
    [AspNetUsersId] NVARCHAR (450) NOT NULL,
    [Description]   NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

