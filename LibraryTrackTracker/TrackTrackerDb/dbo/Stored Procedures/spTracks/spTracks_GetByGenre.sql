CREATE PROCEDURE [dbo].[spTracks_GetByGenre]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name], [Link], [UserId], [ArtistId], [GenreId], [StyleId]
	from [dbo].[Tracks]
	where GenreId = @Id;
END
