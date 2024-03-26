CREATE PROCEDURE [dbo].[spArtists_GetById]
	@Id int

AS
Begin

	set nocount on;

	Select [Id], [Name], [GenreId]
	from [dbo].[Artists]
	where Id = @Id;
END