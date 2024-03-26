CREATE PROCEDURE [dbo].[spGenres_All]
	AS
Begin

	set nocount on; 

	Select [Id], [Name]  
	from [dbo].[Genres]
END

