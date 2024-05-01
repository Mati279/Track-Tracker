CREATE PROCEDURE [dbo].[spArtists_All]
	AS
Begin

	set nocount on; 

	Select [Id], [Name], [GenreId]  
	from [dbo].[Artists]
END

