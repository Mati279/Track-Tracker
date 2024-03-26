CREATE PROCEDURE [dbo].[spStyles_GetById]
	@Id int

AS
Begin

	set nocount on; 

	Select [Id], [Name]
	from [dbo].[Styles]
	where Id = @Id;
END