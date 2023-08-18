CREATE TABLE [dbo].[EkartTokenDetails]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[UserId] INT NOT NULL ,
	[JWTToken] VARCHAR(MAX) NOT NULL  ,
	[RefreshToken] VARCHAR(MAX) NOT NULL, 
    [JWTExpiry] DATETIME NOT NULL, 
    [RefreshExpiry] DATETIME NOT NULL ,

)
