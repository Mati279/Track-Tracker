CREATE PROCEDURE [dbo].[spScores_Insert]
	@Value decimal,
	@TrackId int,
	@UserId int,
	@Stat varchar(50),
	@Id int output

	
AS
BEGIN 
		set nocount on;
		insert into [dbo].[Scores]([Value], [Stat], [User],[TrackId] )
		values(@Value, @Stat, @UserId, @TrackId)

		SET @Id = SCOPE_IDENTITY();
END