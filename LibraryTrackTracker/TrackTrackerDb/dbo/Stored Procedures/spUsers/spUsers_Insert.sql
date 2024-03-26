CREATE PROCEDURE [dbo].[spUsers_Insert]
	@Name nvarchar(220),
	@eMail nvarchar(220),
	@Password int,
	@Id int output

	
AS
BEGIN 
		set nocount on;
		insert into [dbo].[Users]([Name], [eMail], [Password])
		values(@Name, @eMail, @Password)

		SET @Id = SCOPE_IDENTITY();
END
