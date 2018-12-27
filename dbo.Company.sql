CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL,
    [ImageUrl] NVARCHAR(100) NULL, 
	[StreetAdress] NVARCHAR(50) NOT NULL, 
    [ZipCode] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [AccountId] NVARCHAR(450) NOT NULL, 
    [Description] NVARCHAR(1000) NULL,
)
