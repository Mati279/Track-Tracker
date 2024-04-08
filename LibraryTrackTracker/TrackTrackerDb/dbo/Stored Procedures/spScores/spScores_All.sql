CREATE PROCEDURE [dbo].[spScores_All]
	AS
Begin

	set nocount on; 

	Select [Id], [Value], [Stat], [User], [TrackId]  
	from [dbo].[Scores]
END

