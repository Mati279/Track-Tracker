CREATE PROCEDURE [dbo].[spStyles_Insert]
	@Name nvarchar(220),
	@Id int output

	
AS
BEGIN 
		set nocount on;
		insert into [dbo].[Styles]([Name])
		values(@Name)

		SET @Id = SCOPE_IDENTITY();
END