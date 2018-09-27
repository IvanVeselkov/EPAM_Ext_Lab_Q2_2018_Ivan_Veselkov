CREATE PROCEDURE GetAllUsers
  @k INT
AS
DECLARE @i int
set @i = 1
begin
while (@i<=@k) 
begin
select * from Users where ID = @i;
set @i=@i+1
end
end
go
