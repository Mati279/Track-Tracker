CREATE PROCEDURE [dbo].[spUsers_Delete]
		@Id int
AS

BEGIN
			set nocount on; 

			DELETE FROM [dbo].[Users] 
			WHERE Id = @Id
END