CREATE PROCEDURE [dbo].[spStyles_UpdateName]
	@Id int,
	@Name nvarchar(220)
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Styles] 
			Set Name = @Name
			WHERE Id = @Id
END