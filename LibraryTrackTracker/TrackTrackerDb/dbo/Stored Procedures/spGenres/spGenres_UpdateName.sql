CREATE PROCEDURE [dbo].[spGenres_UpdateName]
	@Id int,
	@Name nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Genres] 
			Set Name = @Name
			WHERE Id = @Id
END