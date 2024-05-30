CREATE PROCEDURE [dbo].[spScores_UpdateValue]
	@Id int,
	@Value float
AS

BEGIN
			set nocount on; 

			UPDATE [dbo].[Scores] 
			Set Value = @Value
			WHERE Id = @Id
END