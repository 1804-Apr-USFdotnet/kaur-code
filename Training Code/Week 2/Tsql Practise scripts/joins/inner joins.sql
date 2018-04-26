--  Demonstration B

--  Step 1: Open a new query window to the TSQL database
USE TSQL;
GO

-- Step 2: Join 2 tables
-- Select and execute the following query
-- to demonstrate a two-table inner join.
-- Point out that there are 77 rows output
select * from Production.Categories
select * from Production.Products order by unitprice
/*
21	Product VJZZH	8	3	10.00	0
3	Product IMEHJ	1	2	10.00	0
74	Product BKAZJ	4	7	10.00	0
*/

select unitprice,productid,productname 
from Production.Products 
where productname like 'p%'
group by unitprice,productid,productname
having avg(unitprice)<25
order by unitprice


SELECT c.categoryid, c.categoryname, p.productid, p.productname
FROM Production.Categories AS c
inner JOIN Production.Products AS p
ON c.categoryid = p.categoryid;

-- Step 3: Join 2 tables
-- Select and execute the following query
-- to demonstrate a two-table inner composite join.
-- Point out that there are 27 rows output without a distinct filter
exec sp_help 'Sales.Customers'
select * from Sales.Customers --91
select * from HR.Employees --9
SELECT e.city, e.country
FROM Sales.Customers AS c
JOIN HR.Employees AS e 
ON c.city = e.city AND c.country = e.country;

-- Step 4: Join 2 tables
-- Select and execute the following query
-- to demonstrate a two-table inner composite join.
-- Point out that there are 3 rows output with a distinct filter
SELECT DISTINCT  e.city, e.country
FROM Sales.Customers AS c
JOIN HR.Employees AS e 
ON c.city = e.city AND c.country = e.country;

-- Step 5: Join multiples tables
-- Select and execute the following query
-- to demonstrate a two-table inner join.
-- Point out that the elements needed to add and display data
-- from a third table have been commented out to join
-- the first two tables only
-- 830 rows will be returned
select * from sales.Customers
select * from sales.orders

SELECT c.custid, c.companyname, o.orderid, o.orderdate-- , od.productid, od.qty
FROM Sales.Customers AS c 
JOIN Sales.Orders AS o
ON c.custid = o.custid;

-- JOIN Sales.OrderDetails od
-- ON o.orderid = od.orderid;

-- Step 6: Join 3 tables
-- Select and execute the following query
-- to demonstrate a three-table inner join.
-- 2155 rows will be returned. Why?
SELECT c.custid, c.companyname, o.orderid, o.orderdate, od.productid, od.qty
FROM Sales.Customers AS c 
JOIN Sales.Orders AS o
ON c.custid = o.custid
JOIN Sales.OrderDetails od
ON o.orderid = od.orderid;


select *
from Sales.Orders as o
join Sales.OrderDetails as od
on od.orderid=o.orderid