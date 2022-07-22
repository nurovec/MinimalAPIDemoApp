if not exists (select 1 from dbo.[User])
begin
 insert into dbo.[User](FirstName,LastName)
 values ('Nur','Öveç'),
 ('Burak','Öveç'),
 ('Oğuzhan', 'Keten'),
 ('Tim', 'Corey');

end