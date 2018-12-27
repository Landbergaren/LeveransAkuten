CREATE TABLE [dbo].[Driver]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [ImageUrl] NVARCHAR(100) NULL, 
    [StreetAdress] NVARCHAR(50) NOT NULL, 
    [ZipCode] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [AccountId] NVARCHAR(450) NOT NULL, 
	[Description] NVARCHAR(1000) NULL, 
    [A] BIT NULL DEFAULT 0, 
    [B] BIT NULL DEFAULT 0, 
    [C] BIT NULL DEFAULT 0, 
    [D] BIT NULL DEFAULT 0, 
    [CE] BIT NULL DEFAULT 0,
    FOREIGN KEY ([AccountId]) REFERENCES [dbo].[AspNetUsers] ([Id])
)