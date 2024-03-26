CREATE PROCEDURE [dbo].[spTracks_UpdateArtist]
	@Id int,
	@ArtistId int
	
AS
BEGIN
		UPDATE [dbo].[Tracks]
		SET ArtistId = @ArtistId
		WHERE Id = @Id
END

