CREATE PROCEDURE [dbo].[spArtists_UpdateName]
	@Id int,
	@Name nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Artists] 
			Set Name = @Name
			WHERE Id = @Id
END