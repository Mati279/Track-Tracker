CREATE PROCEDURE [dbo].[spArtists_updateGenre]
	@Id int,
	@GenreId int
	
AS
BEGIN
		UPDATE [dbo].[Artists]
		SET GenreId = @GenreId
		WHERE Id = @Id
END