CREATE PROCEDURE [dbo].[spGenres_GetById]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name]
	from [dbo].[Genres]
	where Id = @Id;
END