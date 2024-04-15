﻿CREATE PROCEDURE [dbo].[spScores_GetById]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Value], [Stat], [UserId], [TrackId]
	from [dbo].[Scores]
	where Id = @Id;
END