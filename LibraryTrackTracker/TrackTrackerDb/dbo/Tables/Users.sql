﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[eMail] NVARCHAR(50)  NOT NULL UNIQUE,
	[Password] NVARCHAR(512) NOT NULL,
)
