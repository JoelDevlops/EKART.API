﻿CREATE TABLE [dbo].[EkartUserInRoles]
(
	[Id] INT NOT NULL PRIMARY KEY  IDENTITY(1,1),
	[UserId] INT NOT NULL  FOREIGN KEY REFERENCES EkartUserDetail(Id) ,
	[RoleId] INT NOT NULL FOREIGN KEY REFERENCES EkartLoopUpRoles(Id),

)
