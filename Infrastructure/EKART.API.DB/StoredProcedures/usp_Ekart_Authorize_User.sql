CREATE PROCEDURE [dbo].[usp_Ekart_Authorize_User]
    @Username NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
SELECT ELR.Name as [Roles] FROM EkartUserInRoles EUIR
LEFT JOIN EkartUserDetail EUD ON EUIR.UserId = EUD.Id
LEFT JOIN EkartLoopUpRoles ELR ON ELR.Id = EUIR.RoleId
where EUD.Email = @Username and EUD.Password = @Password and EUD.IsActive = 1
END
