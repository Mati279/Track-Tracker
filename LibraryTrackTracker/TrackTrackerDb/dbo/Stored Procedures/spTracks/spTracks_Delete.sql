CREATE PROCEDURE [dbo].[spTracks_Delete]

	@Id int
AS

BEGIN
			set nocount on; 

			DELETE FROM [dbo].[Tracks] 
			WHERE Id = @Id
END

