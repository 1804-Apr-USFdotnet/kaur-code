USE TSQL;
GO

--DROP PROCEDURE Add_Product;
--GO
CREATE PROCEDURE Add_Product
(
	@productname nvarchar(100),
	@supplierid INT,
	@categoryid INT
)
AS
	INSERT INTO Production.Products (productname, supplierid, categoryid)
	VALUES ( @productname, @supplierid, @categoryid );
GO

SELECT * FROM Production.Products ORDER BY productid DESC;

DECLARE @supplierid INT, @categoryid INT;
SELECT TOP 1 @supplierid = supplierid FROM Production.Suppliers;
SELECT TOP 1 @categoryid = categoryid FROM Production.Categories;
EXECUTE Add_Product N'Fred', @supplierid, @categoryid;

SELECT * FROM Production.Products ORDER BY productid DESC;

DELETE FROM Production.Products WHERE productname = N'Fred';
