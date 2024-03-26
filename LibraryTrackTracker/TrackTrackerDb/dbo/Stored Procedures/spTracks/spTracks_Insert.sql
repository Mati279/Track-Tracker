CREATE PROCEDURE [dbo].[spTracks_Insert]
	@Name nvarchar(220),
	@Link nvarchar(220),
	@UserId int,
	@ArtistId int,
	@GenreId int,
	@StyleId int,
	@Id int output

	
AS
BEGIN 
		set nocount on;
		insert into [dbo].[Tracks]([Name], [Link], [UserId], [ArtistId], [GenreId], [StyleId])
		values(@Name, @Link, @UserId, @ArtistId, @GenreId, @StyleId)

		SET @Id = SCOPE_IDENTITY();
END
