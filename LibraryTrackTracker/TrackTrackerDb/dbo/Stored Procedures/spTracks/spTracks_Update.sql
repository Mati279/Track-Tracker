CREATE PROCEDURE [dbo].[spTracks_Update]
	@Id int,
    @Name nvarchar(220),
    @Link nvarchar(220),
    @UserId int,
    @ArtistId int,
    @GenreId int,
    @StyleId int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Tracks
    SET Name = @Name,
        Link = @Link,
        UserId = @UserId,
        ArtistId = @ArtistId,
        GenreId = @GenreId,
        StyleId = @StyleId
    WHERE Id = @Id; 
END
