
create database assess;
use assess;


-----------


CREATE TABLE Customers(
    CustomerID INT PRIMARY KEY IDENTITY,
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);


CREATE TABLE Products(
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(100),
    UnitPrice DECIMAL(10,2)
);

CREATE TABLE SalesPersons(
    SalesPersonID INT PRIMARY KEY IDENTITY,
    SalesPersonName VARCHAR(100)
);

CREATE TABLE Orders(
    OrderID INT PRIMARY KEY,
    OrderDate DATE,
    CustomerID INT,
    SalesPersonID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (SalesPersonID) REFERENCES SalesPersons(SalesPersonID)
);


CREATE TABLE OrderItems(
    OrderItemID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    UnitPrice DECIMAL(10,2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);





WITH OrderTotals AS
(
    SELECT
        OrderID,
        SUM(
            CAST(q.value AS INT) *
            CAST(p.value AS DECIMAL(10,2))
        ) AS TotalSales
    FROM Sales_Raw
    CROSS APPLY STRING_SPLIT(Quantities, ',') q
    CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
    GROUP BY OrderID
)

SELECT TOP 1 TotalSales
FROM
(
    SELECT DISTINCT TotalSales,
           DENSE_RANK() OVER (ORDER BY TotalSales DESC) rnk
    FROM OrderTotals
) t
WHERE rnk = 3;




SELECT
    SalesPerson,
    SUM(
        CAST(q.value AS INT) *
        CAST(p.value AS DECIMAL(10,2))
    ) AS TotalSales
FROM Sales_Raw
CROSS APPLY STRING_SPLIT(Quantities, ',') q
CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
GROUP BY SalesPerson
HAVING SUM(
        CAST(q.value AS INT) *
        CAST(p.value AS DECIMAL(10,2))
      ) > 60000;




WITH CustomerTotals AS
(
    SELECT
        CustomerName,
        SUM(
            CAST(q.value AS INT) *
            CAST(p.value AS DECIMAL(10,2))
        ) AS TotalSpent
    FROM Sales_Raw
    CROSS APPLY STRING_SPLIT(Quantities, ',') q
    CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
    GROUP BY CustomerName
)

SELECT *
FROM CustomerTotals
WHERE TotalSpent >
(
    SELECT AVG(TotalSpent)
    FROM CustomerTotals
);



SELECT
    UPPER(CustomerName) AS CustomerName,
    MONTH(CONVERT(date, OrderDate)) AS OrderMonth,
    OrderID
FROM Sales_Raw
WHERE YEAR(CONVERT(date, OrderDate)) = 2026
AND MONTH(CONVERT(date, OrderDate)) = 1;

