CREATE PROCEDURE [dbo].[spGenres_Delete]
			@Id int
AS

BEGIN
			set nocount on; 

			DELETE FROM [dbo].[Genres] 
			WHERE Id = @Id
END