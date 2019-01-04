CREATE TABLE [dbo].[Company] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName]   NVARCHAR (50)  NOT NULL,
    [AspNetUsersId] NVARCHAR (450) NOT NULL,
    [Description]   NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

