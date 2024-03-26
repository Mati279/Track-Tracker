CREATE PROCEDURE [dbo].[spTracks_UpdateLinks]
	@Id int,
	@Link nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Tracks] 
			Set Link = @Link
			WHERE Id = @Id
END