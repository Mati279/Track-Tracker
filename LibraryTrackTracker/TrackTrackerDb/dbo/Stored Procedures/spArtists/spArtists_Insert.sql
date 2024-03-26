CREATE PROCEDURE [dbo].[spArtists_Insert]
	@Name nvarchar(220),
	@GenreId int,
	@Id int output

	
AS
BEGIN 
		set nocount on;
		insert into [dbo].[Artists]([Name], [GenreId])
		values(@Name, @GenreId)

		SET @Id = SCOPE_IDENTITY();
END
