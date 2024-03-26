CREATE PROCEDURE [dbo].[spTracks_GetByUser]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name], [Link], [UserId], [ArtistId], [GenreId], [StyleId]
	from [dbo].[Tracks]
	where UserId = @Id;
END
