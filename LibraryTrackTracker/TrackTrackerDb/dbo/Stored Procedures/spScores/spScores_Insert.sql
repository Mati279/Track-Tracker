﻿CREATE PROCEDURE [dbo].[spScores_Insert]
	@Value float,
	@TrackId int,
	@UserId int,
	@Stat varchar(50),
	@Id int output

	
AS
BEGIN 
		set nocount on;
		insert into [dbo].[Scores]([Value], [Stat], [UserId],[TrackId] )
		values(@Value, @Stat, @UserId, @TrackId)

		SET @Id = SCOPE_IDENTITY();
END