CREATE TABLE [dbo].[EkartLoopUpRoles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] Varchar(100) NOT NULL,
	[Description] Varchar(MAX) NOT NULL,
	[CreatedBy] VARCHAR(100) NOT NULL,
	[CreatedOn] Datetime NOT NULL,
	[UpdatedBy] VARCHAR(100)  NULL,
	[UpdatedOn] Datetime  NULL,
	[IsActive] BIT NOT NULL
)
