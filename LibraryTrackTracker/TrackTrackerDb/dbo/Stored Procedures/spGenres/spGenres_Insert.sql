CREATE PROCEDURE [dbo].[spGenres_Insert]
	@Name nvarchar(220),
	@Id int output

	
AS
BEGIN 
		set nocount on;
		insert into [dbo].[Genres]([Name])
		values(@Name)

		SET @Id = SCOPE_IDENTITY();
END