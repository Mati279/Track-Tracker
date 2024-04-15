CREATE PROCEDURE [dbo].[spScores_All]
	AS
Begin

	set nocount on; 

	Select [Id], [Value], [Stat], [UserId], [TrackId]  
	from [dbo].[Scores]
END

