CREATE PROCEDURE [dbo].[spUsers_UpdatePassword]
	@Id int,
	@Password nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Users] 
			Set Password = @Password
			WHERE Id = @Id
END
