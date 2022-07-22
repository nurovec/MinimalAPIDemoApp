CREATE PROCEDURE [dbo].[sp_User_GetAll]
AS
begin
 select Id ,FirstName,LastName
 from dbo.[User]
end
