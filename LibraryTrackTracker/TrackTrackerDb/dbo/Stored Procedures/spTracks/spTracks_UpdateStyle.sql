CREATE PROCEDURE [dbo].[spTracks_UpdateStyle]
	@Id int,
	@StyleId int
	
AS
BEGIN
		UPDATE [dbo].[Tracks]
		SET StyleId = @StyleId
		WHERE Id = @Id
END