CREATE PROCEDURE [dbo].[usp_Ekart_Get_Product_Category]
	@IsActive bit
AS
BEGIN
	SELECT
	[Id],
	[Name],
	[Description] ,
	[IsActive] ,
	[CreatedBy] ,
	[CreatedOn] ,
	[UpdatedBy],
	[UpdatedOn] from EkartProductCategory where IsActive = @IsActive
END
