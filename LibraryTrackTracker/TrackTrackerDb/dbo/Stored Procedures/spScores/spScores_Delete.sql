CREATE PROCEDURE [dbo].[spScores_Delete]
			@Id int
AS

BEGIN
			set nocount on; 

			DELETE FROM [dbo].[Scores] 
			WHERE Id = @Id
END