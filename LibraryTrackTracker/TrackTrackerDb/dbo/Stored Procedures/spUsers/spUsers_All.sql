CREATE PROCEDURE [dbo].[spUsers_All]
	
AS
Begin

	set nocount on; 

	Select [Id], [Name], [eMail], [Password]   
	from [dbo].[Users]
END
