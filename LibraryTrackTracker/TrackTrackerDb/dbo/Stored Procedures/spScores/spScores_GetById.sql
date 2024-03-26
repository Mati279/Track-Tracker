CREATE PROCEDURE [dbo].[spScores_GetById]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Value], [Stat], [User], [Track]
	from [dbo].[Scores]
	where Id = @Id;
END