CREATE PROCEDURE [dbo].[spStyles_Delete]
			@Id int
AS

BEGIN
			set nocount on; 

			DELETE FROM [dbo].[Styles] 
			WHERE Id = @Id
END