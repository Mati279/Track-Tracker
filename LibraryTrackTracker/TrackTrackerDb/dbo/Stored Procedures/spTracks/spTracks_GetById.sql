CREATE PROCEDURE [dbo].[spTracks_GetById]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name], [Link], [UserId], [ArtistId], [GenreId], [StyleId]
	from [dbo].[Tracks]
	where Id = @Id;
END

