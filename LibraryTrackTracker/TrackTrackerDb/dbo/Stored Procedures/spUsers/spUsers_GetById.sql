CREATE PROCEDURE [dbo].[spUsers_GetById]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name], [eMail], [Password]
	from [dbo].[Users]
	where Id = @Id;
END