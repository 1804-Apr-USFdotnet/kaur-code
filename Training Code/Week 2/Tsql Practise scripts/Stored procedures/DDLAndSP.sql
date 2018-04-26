--alter database [MyDBAdvWorks]

USE [master];
--GO
--ALTER DATABASE RevatureDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--GO
----alter database sample2 modify name =RevatureDb
--exec sp_renamedb '[RevatureDb]', 'RevatureDb1'

create database Revature
--drop database data1 
use revature
Create schema Sales
go
create table Sales.Product
(
ProductID integer identity primary key,
Name varchar(20),
price decimal null
);
alter table sales.product
add Supplier integer not null
constraint def_supplier default 1;-- add constraint to new column

alter table sales.product
add constraint def_product_price
default 0.0 for price  ---add constraint to existing columns

insert into sales.Product(Name) values ('pillows')
select * from sales.Product
alter table sales.product
drop constraint def_product_price


--drop schema sales
--drop table sales.product

insert into Sales.Product values('Linen',20.0,1);
insert into Sales.Product(name)  values ('plastic')
insert into Sales.Product (Name,price) values ('sheet',null)-- error
select * from Sales.Product

--drop table Sales.Supplier
create table Sales.Supplier
(
supplierId integer,
Name varchar(20) not null,
phone char(10) null
primary key(supplierId)
)
insert into sales.supplier values(1,'Target','555-12344'),(2,'Walmart','555-54331')
select * from Sales.Supplier
--delete Sales.Supplier

--constraints
--- adding refernce with foreign key
alter table Sales.Product
add constraint fk_product_supplier-- name the constraint
foreign key (supplier) references sales.supplier(supplierid)


insert into sales.supplier values(10,'Walmart','555-1234')
-- Start in master
USE MASTER;

 --Add users
GO
ALTER DATABASE Revature SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
--alter database sample2 modify name =RevatureDb
exec sp_renamedb 'Revature', 'RevatureDb'
ALTER DATABASE Revature SET MULTI_USER
GO
use [RevatureDb]

select * from sales.Product
select * from sales.supplier
insert into sales.product values('Tissues',10.0,2)-- conflict with foriegn key
delete from sales.Supplier where supplierId=1--not allowed

-------------------Select commands recall
select * from Sales.Product where Supplier <> 1 -- != not equal
select * from sales.Product	where price =10 or price=20 
select * from sales.Product where price in(20,10)
select * from sales.Product where price between 0 and 10
select * from sales.Product where name like 'p%' --starts with p
select * from sales.Product where name like 'p_l%'
select * from sales.Product where name like '[^c,^p]%'--not like within brackets
select top 75 percent * from sales.Product

---------------SP
select productid,Name, price,Supplier from sales.[Product]

-- procedure without parameter
create proc sp_GetProducts
as 
begin
     select productid,Name, price,Supplier from sales.Product
end
 execute sp_getproducts1

 exec sp_rename sp_getproducts,sp_getproducts1
 sp_renamedb
   --Sales.Product alt+fn+f1

   --procedure with input parameters
 create proc spgetProductBySupplierId
 @supplierId int --param
 as 
 begin
  select * from  sales.Product 
   where Supplier=@supplierid
 end

 exec spgetProductBySupplierId 1
 sp_helptext spgetProductBySupplierId
 sp_helptext sp_getProducts1

 alter proc spgetProductBySupplierId
 @supplierid int
 with encryption--to not allow to see the defination
 as 
 begin
  select * from  sales.Product 
 where Supplier=@supplierid
 end

 sp_helptext spgetProductBySupplierId
 drop proc spgetProductBySupplierId

 sp_helptext sp_rename

 ----  SP with output parameters
 select count(productId) from sales.Product
 where supplier=1

 create proc spGetproductCountBySupplierId
 @Productcount int output,
 @supplier int
 as
 begin
 select @Productcount=count(productId) from sales.Product
 where supplier=@supplier
 end

declare @prodcount int-- similar to output parameter
--exec spGetproductCountBySupplierId @prodcount out,@supplier = 1
exec spGetproductCountBySupplierId @prodcount output , 1-- considering prodcount as null
print @prodcount

create proc spGetTotalProduct1
@totalproduct int out
as 
begin
     select @totalproduct=count(productId) from Sales.product
 end

 declare @test int
 exec spGetTotalProduct1 @test out
 print @test

alter proc spGetTotalProduct2
as 
begin
 select count(productId) from Sales.product
end

declare @totalproduct int
exec spGetTotalProduct1 @totalproduct out
print @totalproduct

declare @totalproduct1 int
exec @totalproduct1=spGetTotalProduct2
print @totalproduct1

--difference between return and out
alter proc spGetProductNameById
@Id int,
@Name nvarchar(20) out
as 
begin
 --return(select count(productId) from Sales.product)
 select @Name=name from Sales.Product where ProductID=@Id
 return(select count(productId) from Sales.product)
end

exec sp_helptext spGetProductNameById

 declare @items int
 declare @name1 nvarchar(20)
 exec @items=spGetProductNameById @Id=1, @Name=@name1 out
 print 'Name='+@name1
 print @items


create proc spGetProductNameById2
@Id int
as 
begin
return(select count(productId) from Sales.product)
return (select name from Sales.Product where ProductID=@Id)
 end

 declare @name2 nvarchar(20)
 exec @name2=spGetProductNameById2 1
 print 'Name='+@name2



--system SPs sp_help =>alt+f1 (used by tables, SP's, Views, triggers), 
-------------sp_helptext spname
sp_depends 'spGetproductCountBySupplierId'

sp_depends 'sales.Product'



