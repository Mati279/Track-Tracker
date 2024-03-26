CREATE PROCEDURE [dbo].[spTracks_GetByArtist]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name], [Link], [UserId], [ArtistId], [GenreId], [StyleId]
	from [dbo].[Tracks]
	where ArtistId = @Id;
END
