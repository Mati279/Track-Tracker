CREATE PROCEDURE [dbo].[spTracks_UpdateName]
	@Id int,
	@Name nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Tracks] 
			Set Name = @Name
			WHERE Id = @Id
END



	

