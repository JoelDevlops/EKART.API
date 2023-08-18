CREATE TABLE [dbo].[EkartUserDetail]
(
	[Id] INT NOT NULL  PRIMARY KEY IDENTITY(1,1),
	[FirstName] VARCHAR(50) NOT NULL,
	[MiddleName] VARCHAR(50) NULL,
	[Email] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(100) NOT NULL,
	[CreatedBy] VARCHAR(100) NOT NULL,
	[CreatedOn] Datetime NOT NULL,
	[UpdatedBy] VARCHAR(100)  NULL,
	[UpdatedOn] Datetime  NULL,
	[IsActive] BIT NOT NULL
)
