CREATE TABLE [dbo].[Ad]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Header] NCHAR(50) NULL, 
    [Description] NCHAR(1000) NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL,
    [ARequired] BIT NULL DEFAULT 0, 
    [BRequired] BIT NULL DEFAULT 0, 
    [CRequired] BIT NULL DEFAULT 0, 
    [DRequired] BIT NULL DEFAULT 0, 
    [CERequired] BIT NULL DEFAULT 0, 
    [CompanyId] INT NOT NULL,	
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id])
)
