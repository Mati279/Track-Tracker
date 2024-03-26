CREATE PROCEDURE [dbo].[spTracks_UpdateName]
	@Id int,
	@Title nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Tracks] 
			Set Title = @Title
			WHERE Id = @Id
END



	

