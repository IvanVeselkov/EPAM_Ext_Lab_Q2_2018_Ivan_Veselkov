--1.1	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) включительно и которые доставлены с ShipVia >= 2.
select OrderID,ShippedDate,ShipVia from Northwind.Northwind.Orders where ShipVia >=2 and ShippedDate >= DATEADD(Y,0,'1998-05-05 0:0:0.000');--как ты понимаешь, где у тебя месяц, а где у тебя дата? Нужно сделать запрос независимым от культуры. CONVERT(DATETIME, '19980506', 101)
--1.2 	Написать запрос, который выводит только недоставленные заказы из таблицы Orders. 
select OrderID,
case
when ShippedDate IS null then 'Not Shipped' 
end as 'Shipped Date'
from Northwind.Northwind.Orders where ShippedDate is null;
--1.3	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) не включая эту дату или которые еще не доставлены. 
select OrderID 'Order Number',--ShippedDate 'Shipped Date'
case 
when ShippedDate is null then 'Not Shipped'
else CONVERT(char,ShippedDate,121)
end 'Shipped Date'
 from Northwind.Northwind.Orders
 where ShippedDate > DATEADD(Y,0,'1998-05-06 0:0:0.000') or ShippedDate is NUll ;
--2.1	Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada.
select ContactName,Country from Northwind.Northwind.Customers
 where Country in ('USA','Canada') order by ContactName ASC,Country ASC
--2.2	Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada.
select ContactName,Country from Northwind.Northwind.Customers
 where Country not in ('USA','Canada') order by ContactName ASC,Country ASC
--2.3	Выбрать из таблицы Customers все страны, в которых проживают заказчики.
select distinct Country from Northwind.Northwind.Customers order by Country DESC
--3.1	Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться), где встречаются продукты с количеством от 3 до 10 включительно
select OrderID,Quantity from Northwind.Northwind.[Order Details]
where Quantity BETWEEN 3 and 10
--3.2	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g. 
select CustomerID,Country from Northwind.Northwind.Customers where Country BETWEEN 'b%' and 'h%'
order by Country ASC
--3.3	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g, не используя оператор BETWEEN. 
select CustomerID,Country from Northwind.Northwind.Customers 
where	Country Like 'b%' or
		Country Like 'c%' or
		Country Like 'd%' or
		Country Like 'e%' or
		Country Like 'f%' or
		Country Like 'g%'
order by Country ASC
--4.1	В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'. 
select ProductName from Northwind.Northwind.Products where ProductName like '%cho_olade%'
--5.1	Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и скидок по ним. 
select ROUND( SUM((UnitPrice - UnitPrice*Discount)*Quantity),2,1.0) 'Totals' 
from Northwind.Northwind.[Order Details]
--5.2	По таблице Orders найти количество заказов, которые еще не были доставлены 
select 
COUNT(
case 
when ShippedDate is null then ''
end
) 'Counts'
from Northwind.Northwind.Orders 

--5.3	По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы
select COUNT(CustomerID) from Northwind.Northwind.Orders

--6.1	По таблице Orders найти количество заказов с группировкой по годам.
select COUNT(OrderID), YEAR(OrderDate) from Northwind.Northwind.Orders 
group by YEAR(OrderDate)
--6.2	По таблице Orders найти количество заказов, cделанных каждым продавцом.
select (select FirstName+' '+LastName from Northwind.Northwind.Employees as e where e.EmployeeID=o.EmployeeID) 'Seller',
COUNT(EmployeeID) 'Amount' from Northwind.Northwind.Orders as o
group by EmployeeID
--6.3	По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя. 
select (select FirstName+' '+LastName from Northwind.Northwind.Employees EMP where EMP.EmployeeID=ORD.EmployeeID) 'Sellers', -- All кто за тебя вместо NULL писать будет?
(select ContactName from Northwind.Northwind.Customers CUST where CUST.CustomerID=ORD.CustomerID) 'Customer',
COUNT(OrderDate) 'Amount' 
from Northwind.Northwind.Orders ORD 
where YEAR(OrderDate)=CONVERT(int,'1998') 
group by CUBE(EmployeeID,CustomerID) 
order by Amount ASC

--6.4	Найти покупателей и продавцов, которые живут в одном городе. Если в городе живут только один или несколько продавцов или только один или несколько покупателей, то информация о таких покупателя и продавцах не должна попадать в результирующий набор. 
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
              
--6.5 	Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение таблицы Customers c собой - самосоединение. 
select CUST1.CustomerID,CUST1.City
from Northwind.Northwind.Customers CUST1 inner join Northwind.Northwind.Customers CUST2 
on CUST1.City = CUST2.City where CUST1.CustomerID <> CUST2.CustomerID
group by CUST1.City,CUST1.CustomerID
order by CUST1.City ASC

--6.6 	По таблице Employees найти для каждого продавца его руководителя
select * from Northwind.Northwind.Employees
select 
EMP1.FirstName+' '+EMP1.LastName 'User Name',
(select EMP2.FirstName+' '+EMP2.LastName from Northwind.Northwind.Employees EMP2 where EMP1.ReportsTo=EMP2.EmployeeID) 'BOSS' 
from Northwind.Northwind.Employees EMP1
--7.1	Определить продавцов, которые обслуживают регион 'Western' 
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
					
--8.1	Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество их заказов из таблицы Orders.
select (select ContactName from Northwind.Northwind.Customers C where C.CustomerID=o.CustomerID) 'Customer',
COUNT(OrderID) 'Amount Orders' from Northwind.Northwind.Orders as o
group by CustomerID

--9.1	Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя бы одного продукта на складе
select CompanyName from Northwind.Northwind.Suppliers 
where SupplierID in (select SupplierID from Northwind.Northwind.Products where UnitsInStock =0)
--Можно ли использовать вместо оператора IN оператор '=' ?
--да если селект возвращает одну строку
--10.1	Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный коррелированный SELECT.
select (select FirstName+' '+LastName from Northwind.Northwind.Employees as e where e.EmployeeID=o.EmployeeID) 'Seller',
COUNT(EmployeeID) 'Amount' from Northwind.Northwind.Orders as o
group by EmployeeID having COUNT(EmployeeID)>150

--11.1	Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа 
select (select ContactName from Northwind.Northwind.Customers C where C.CustomerID=o.CustomerID) 'Customer',
COUNT(OrderID) 'Amount Orders' from Northwind.Northwind.Orders as o where EXISTS(select * from Northwind.Northwind.Orders)
group by CustomerID having COUNT(OrderID)=0

--12.1	Для формирования алфавитного указателя Employees высветить из таблицы Employees список только тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы. 
select distinct SUBSTRING(LastName,1,1) as bukva from Northwind.Northwind.Employees order by bukva

--13.1	Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный год.
exec dbo.GreatestOrders 1998
--13.2	Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку доставки в днях
exec dbo.ShippedOrdersDiff 
--13.3	Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, так и подчиненных его подчиненных. 
exec dbo.SubordinationInfo 7
--13.4  Написать функцию, которая определяет, есть ли у продавца подчиненные. Возвращает тип данных BIT. 
exec dbo.IsBoss 1