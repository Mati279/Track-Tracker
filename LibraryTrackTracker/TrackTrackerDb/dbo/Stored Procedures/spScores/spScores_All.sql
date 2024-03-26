CREATE PROCEDURE [dbo].[spScores_All]
	AS
Begin

	set nocount on; 

	Select [Id], [Value], [Stat], [User], [Track]  
	from [dbo].[Scores]
END

