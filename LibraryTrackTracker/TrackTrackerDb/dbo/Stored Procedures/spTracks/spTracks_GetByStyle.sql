CREATE PROCEDURE [dbo].[spTracks_GetByStyle]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name], [Link], [UserId], [ArtistId], [GenreId], [StyleId]
	from [dbo].[Tracks]
	where StyleId = @Id;
END