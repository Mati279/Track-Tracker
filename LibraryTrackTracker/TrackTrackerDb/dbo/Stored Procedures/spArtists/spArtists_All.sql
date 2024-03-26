CREATE PROCEDURE [dbo].[spArtists_All]
	AS
Begin

	set nocount on; 

	Select [Id], [Name]  
	from [dbo].[Artists]
END

