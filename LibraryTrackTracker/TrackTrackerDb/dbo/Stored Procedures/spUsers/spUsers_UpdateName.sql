﻿CREATE PROCEDURE [dbo].[spUsers_UpdateName]
	@Id int,
	@Name nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Users] 
			Set Name = @Name
			WHERE Id = @Id
END