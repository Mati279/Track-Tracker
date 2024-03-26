CREATE PROCEDURE [dbo].[spArtists_Delete]
			@Id int
AS

BEGIN
			set nocount on; 

			DELETE FROM [dbo].[Artists] 
			WHERE Id = @Id
END