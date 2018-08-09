--13.1
create  procedure GreatestOrders @year INT
as 
DECLARE @max_price int;
select
E.FirstName,
E.LastName,
O.OrderID,
((OD.UnitPrice * (1 - OD.Discount)) * OD.Quantity) as 'MAX PRISE'
from
Northwind.Northwind.Employees E 
inner join Northwind.Northwind.Orders O on E.EmployeeID = O.EmployeeID
inner join Northwind.Northwind.[Order Details] OD on O.OrderID = OD.OrderID
where 
YEAR(o.OrderDate) = @year
and
((OD.UnitPrice * (1 - OD.Discount)) * OD.Quantity)=(select MAX(((OD1.UnitPrice * (1 - OD1.Discount)) * OD1.Quantity))	
													from 
													Northwind.Northwind.Orders O1 
													inner join
													Northwind.Northwind.[Order Details] OD1
													on
													O1.OrderID = OD1.OrderID
													where
													YEAR(O1.OrderDate)=@year)
go													
--13.2
create procedure ShippedOrdersDiff @defDay INT = 35
as
select OrderID,OrderDate,ShippedDate,DATEDIFF(d, OrderDate, ShippedDate) as ShippedDelay,@defDay as SpecifiedDelay from Northwind.Northwind.Orders
where ShippedDate is null or DATEDIFF(d, OrderDate, ShippedDate)>@defDay

go
--13.3
CREATE PROCEDURE SubordinationInfo @sell_id int
as
DECLARE @str nvarchar(100)= '';
DECLARE @result nvarchar(100);
while(@sell_id is not null)
begin
set @result = (select @str + LastName from Northwind.Northwind.Employees where EmployeeID = @sell_id)
print @result
set @sell_id = (select ReportsTo from Northwind.Northwind.Employees where EmployeeID = @sell_id)
set @str = @str+' '
end
go
--13.4
create function IsBoss (@id INT)
returns bit
as
begin
if(EXISTS(select EmployeeID from Northwind.Northwind.Employees where ReportsTo = @id))
	return 1
return 0
end
