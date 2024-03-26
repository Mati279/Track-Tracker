CREATE PROCEDURE [dbo].[spUsers_UpdateEmail]
	@Id int,
	@eMail nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Users] 
			Set eMail = @eMail
			WHERE Id = @Id
END