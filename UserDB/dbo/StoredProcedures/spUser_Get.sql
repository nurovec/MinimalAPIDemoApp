CREATE PROCEDURE [dbo].[sp_User_Get]
	@Id int
AS
begin 
select Id,FirstName,LastName
from dbo.[User]
where Id = @Id;
end
