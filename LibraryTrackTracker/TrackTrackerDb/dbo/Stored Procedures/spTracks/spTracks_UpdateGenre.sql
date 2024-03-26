CREATE PROCEDURE [dbo].[spTracks_UpdateGenre]
	@Id int,
	@GenreId int
	
AS
BEGIN
		UPDATE [dbo].[Tracks]
		SET GenreId = @GenreId
		WHERE Id = @Id
END