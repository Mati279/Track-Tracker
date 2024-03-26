CREATE PROCEDURE [dbo].[spStyles_All]
	AS
Begin

	set nocount on; 

	Select [Id], [Name]  
	from [dbo].[Styles]
END

