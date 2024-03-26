CREATE PROCEDURE [dbo].[spTracks_All]
	
AS
Begin

	set nocount on; 

	Select [Id], [Name], [Link], [UserId], [ArtistId], [GenreId], [StyleId]
	from [dbo].[Tracks]
END
