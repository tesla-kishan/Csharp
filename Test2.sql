Create Database Test2;
use Test2;


-- table Sales_Raw

--Question 1 – Normalization (Design Thinking)
--The Sales_Raw table violates normalization rules.
--Tasks:
--Identify at least three normalization problems
--Redesign the database into proper normalized tables (minimum 3NF)
--Write CREATE TABLE statements for the new design
--(No data migration required, only structure)

CREATE TABLE CustomerMaster(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);

INSERT INTO CustomerMaster VALUES
(1, 'Ravi Kumar', '9876543210', 'Chennai'),
(2, 'Priya Sharma', '9123456789', 'Bangalore'),
(3, 'John Peter', '9988776655', 'Hyderabad');



CREATE TABLE ProductMaster(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    UnitPrice DECIMAL(10,2)
);

INSERT INTO ProductMaster VALUES
(1, 'Laptop', 55000),
(2, 'Mouse', 500),
(3, 'Keyboard', 1500),
(4, 'Monitor', 12000);


CREATE TABLE SalesPersonMaster(
    SalesPersonID INT PRIMARY KEY,
    SalesPersonName VARCHAR(100)
);

INSERT INTO SalesPersonMaster VALUES
(1, 'Anitha'),
(2, 'Suresh');


CREATE TABLE OrderMaster(
    OrderID INT PRIMARY KEY,
    OrderDate DATE,
    CustomerID INT,
    SalesPersonID INT,
    FOREIGN KEY (CustomerID) REFERENCES CustomerMaster(CustomerID),
    FOREIGN KEY (SalesPersonID) REFERENCES SalesPersonMaster(SalesPersonID)
);

INSERT INTO OrderMaster VALUES
(101, '2024-01-05', 1, 1),
(102, '2024-01-06', 2, 1),
(103, '2024-01-10', 1, 2),
(104, '2024-02-01', 3, 1),
(105, '2024-02-10', 2, 2);


CREATE TABLE OrderDetails(
    OrderDetailID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    UnitPrice DECIMAL(10,2),
    FOREIGN KEY(OrderID) REFERENCES OrderMaster(OrderID),
    FOREIGN KEY(ProductID) REFERENCES ProductMaster(ProductID)
);

INSERT INTO OrderDetails(OrderID,ProductID,Quantity,UnitPrice) VALUES
(101,1,1,55000),
(101,2,2,500),

(102,3,1,1500),
(102,2,1,500),

(103,1,1,54000),

(104,4,1,12000),
(104,2,1,500),

(105,1,1,56000),
(105,3,1,1500);


--Question 2 – Third Highest Total Sales (Analytical Query)
--Each order may contain multiple products.
--Task:
--Write a SQL query to find the third highest total sales amount, where:
--Total Sales = Quantity × Unit Price (for all products in an order)
--Hint: You may need STRING_SPLIT, CROSS APPLY, or window functions.


WITH OrderTotals AS (
    SELECT 
        OrderID,
        SUM(Quantity * UnitPrice) AS TotalSales
    FROM OrderDetails
    GROUP BY OrderID
),
Ranked AS (
    SELECT *,
           DENSE_RANK() OVER(ORDER BY TotalSales DESC) AS rnk
    FROM OrderTotals
)
SELECT TotalSales
FROM Ranked
WHERE rnk = 3;


--Question 3 – GROUP BY & HAVING (Business Rule)
--Management wants to identify salespersons who generated high revenue.
--Task:
--Write a query to list SalesPerson names whose total sales amount is greater than ₹60,000.
--Use:
--GROUP BY
--HAVING

SELECT 
    sp.SalesPersonName,
    SUM(od.Quantity * od.UnitPrice) AS TotalSales
FROM OrderMaster o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN SalesPersonMaster sp ON o.SalesPersonID = sp.SalesPersonID
GROUP BY sp.SalesPersonName
HAVING SUM(od.Quantity * od.UnitPrice) > 60000;


--Question 4 – Subquery Usage
--The company wants to find customers who spent more than the average customer spending.
--Task:
--Write a query using a subquery to display:
--CustomerName
--Total amount spent
--Only include customers whose total spending is above the average spending of all customers.

SELECT 
    CustomerName,
    TotalSpent
FROM (
    SELECT 
        c.CustomerName,
        SUM(od.Quantity * od.UnitPrice) AS TotalSpent
    FROM CustomerMaster c
    JOIN OrderMaster o ON c.CustomerID = o.CustomerID
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY c.CustomerName
) AS T
WHERE TotalSpent >
(
    SELECT AVG(TotalSpent)
    FROM (
        SELECT SUM(Quantity * UnitPrice) AS TotalSpent
        FROM OrderMaster o
        JOIN OrderDetails od ON o.OrderID = od.OrderID
        GROUP BY o.CustomerID
    ) X
);


--Question 5 – String & Date Functions
--Operations team wants formatted and filtered data.
--Tasks:
--Display CustomerName in UPPERCASE
--Extract Order Month from OrderDate
--Show only orders placed in January 2026


SELECT 
    UPPER(c.CustomerName) AS CustomerName,
    MONTH(o.OrderDate) AS OrderMonth,
    o.OrderDate
FROM OrderMaster o
JOIN CustomerMaster c ON o.CustomerID = c.CustomerID
WHERE YEAR(o.OrderDate) = 2024
  AND MONTH(o.OrderDate) = 1;
