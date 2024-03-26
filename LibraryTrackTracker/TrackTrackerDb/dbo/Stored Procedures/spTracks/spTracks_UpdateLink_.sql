CREATE PROCEDURE [dbo].[spTracks_UpdateLink]
	@Id int,
	@Link nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Tracks] 
			Set Link = @Link
			WHERE Id = @Id
END