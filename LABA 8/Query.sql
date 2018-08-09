--1.1
select OrderID,ShippedDate,ShipVia from Northwind.Northwind.Orders where ShipVia >=2 and ShippedDate >= DATEADD(Y,0,'1998-05-05 0:0:0.000');
--1.2
select OrderID,
case
when ShippedDate IS null then 'Not Shipped' 
end as 'Shipped Date'
from Northwind.Northwind.Orders where ShippedDate is null;
--1.3
select OrderID 'Order Number',--ShippedDate 'Shipped Date'
case 
when ShippedDate is null then 'Not Shipped'
else CONVERT(char,ShippedDate,121)
end 'Shipped Date'
 from Northwind.Northwind.Orders
 where ShippedDate > DATEADD(Y,0,'1998-05-06 0:0:0.000') or ShippedDate is NUll ;
--2.1
select ContactName,Country from Northwind.Northwind.Customers
 where Country in ('USA','Canada') order by ContactName ASC,Country ASC
--2.2
select ContactName,Country from Northwind.Northwind.Customers
 where Country not in ('USA','Canada') order by ContactName ASC,Country ASC
--2.3
select distinct Country from Northwind.Customers order by Country DESC
--3.1
select OrderID,Quantity from Northwind.Northwind.[Order Details]
where Quantity BETWEEN 3 and 10
--3.2
select CustomerID,Country from Northwind.Northwind.Customers where Country BETWEEN 'b%' and 'h%'
order by Country ASC
--3.3
select CustomerID,Country from Northwind.Northwind.Customers 
where	Country Like 'b%' or
		Country Like 'c%' or
		Country Like 'd%' or
		Country Like 'e%' or
		Country Like 'f%' or
		Country Like 'g%'
order by Country ASC
--4.1
select ProductName from Northwind.Northwind.Products where ProductName like '%cho_olade%'
--5.1
select ROUND( SUM((UnitPrice - UnitPrice*Discount)*Quantity),2,1.0) 'Totals' 
from Northwind.Northwind.[Order Details]
--5.2
select 
COUNT(
case 
when ShippedDate is null then ''
end
) 'Counts'
from Northwind.Northwind.Orders 

--5.3
select COUNT(CustomerID) from Northwind.Northwind.Orders

--6.1
select COUNT(OrderID), YEAR(OrderDate) from Northwind.Northwind.Orders 
group by YEAR(OrderDate)
--6.2
select (select FirstName+' '+LastName from Northwind.Northwind.Employees as e where e.EmployeeID=o.EmployeeID) 'Seller',
COUNT(EmployeeID) 'Amount' from Northwind.Northwind.Orders as o
group by EmployeeID
--6.3
select (select FirstName+' '+LastName from Northwind.Northwind.Employees EMP where EMP.EmployeeID=ORD.EmployeeID) 'Sellers',
(select ContactName from Northwind.Northwind.Customers CUST where CUST.CustomerID=ORD.CustomerID) 'Customer',
COUNT(OrderDate) 'Amount' 
from Northwind.Northwind.Orders ORD 
where YEAR(OrderDate)=CONVERT(int,'1998') 
group by CUBE(EmployeeID,CustomerID) 
order by Amount ASC

--6.4
SELECT c.ContactName AS Person, 'Customer' AS Type,c.City AS City
FROM Northwind.Northwind.Customers AS c
WHERE EXISTS (
              SELECT e.City 
              FROM Northwind.Northwind.Employees AS e
              WHERE e.City=c.City
              )
UNION ALL
SELECT e.FirstName+' '+e.LastName AS Person, 'Seller' AS Type,e.City AS City
FROM Northwind.Northwind.Employees AS e
WHERE EXISTS (
              SELECT c.City 
              FROM Northwind.Northwind.Customers AS c
              WHERE e.City=c.City
              )
              
--6.5
select CUST1.CustomerID,CUST1.City
from Northwind.Northwind.Customers CUST1 inner join Northwind.Northwind.Customers CUST2 
on CUST1.City = CUST2.City where CUST1.CustomerID <> CUST2.CustomerID
group by CUST1.City,CUST1.CustomerID
order by CUST1.City ASC

--6.6
select * from Northwind.Northwind.Employees
select 
EMP1.FirstName+' '+EMP1.LastName 'User Name',
(select EMP2.FirstName+' '+EMP2.LastName from Northwind.Northwind.Employees EMP2 where EMP1.ReportsTo=EMP2.EmployeeID) 'BOSS' 
from Northwind.Northwind.Employees EMP1
--7
select E.LastName,
(select 
case
when T.TerritoryID = Et.TerritoryID then T.TerritoryDescription
end
from Northwind.Northwind.Region R inner join Northwind.Northwind.Territories T 
on R.RegionID=T.RegionID 
where R.RegionDescription = 'Western' and ET.TerritoryID = T.TerritoryID
) as 'Tera' from Northwind.Northwind.EmployeeTerritories ET inner join Northwind.Northwind.Employees E on E.EmployeeID=ET.EmployeeID
where ET.EmployeeID in 
					(select EmployeeID 
					from Northwind.Northwind.Employees E
					where EmployeeID in(
					select EmployeeID 
					from Northwind.Northwind.EmployeeTerritories
					where 
					TerritoryID in (
					select TerritoryID 
					from Northwind.Northwind.Territories 
					where RegionID = (
					select RegionID 
					from Northwind.Northwind.Region RE 
					where RegionDescription = 'Western'))))
					
--8
select (select ContactName from Northwind.Northwind.Customers C where C.CustomerID=o.CustomerID) 'Customer',
COUNT(OrderID) 'Amount Orders' from Northwind.Northwind.Orders as o
group by CustomerID

--9
select CompanyName from Northwind.Northwind.Suppliers 
where SupplierID in (select SupplierID from Northwind.Northwind.Products where UnitsInStock =0)
--10
select (select FirstName+' '+LastName from Northwind.Northwind.Employees as e where e.EmployeeID=o.EmployeeID) 'Seller',
COUNT(EmployeeID) 'Amount' from Northwind.Northwind.Orders as o
group by EmployeeID having COUNT(EmployeeID)>150

--11
select (select ContactName from Northwind.Northwind.Customers C where C.CustomerID=o.CustomerID) 'Customer',
COUNT(OrderID) 'Amount Orders' from Northwind.Northwind.Orders as o where EXISTS(select * from Northwind.Northwind.Orders)
group by CustomerID having COUNT(OrderID)=0

--12
select distinct SUBSTRING(LastName,1,1) as bukva from Northwind.Northwind.Employees order by bukva

--13.1
exec dbo.GreatestOrders 1998
--13.2
exec dbo.ShippedOrdersDiff 
--13.3
exec dbo.SubordinationInfo 7
--13.4
exec dbo.IsBoss 1