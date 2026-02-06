create database day12;
use day12;


/* ===============================
   STEP 1 — Create Employees Table
================================*/
CREATE TABLE Employees (
    EmpID INT IDENTITY(1,1) PRIMARY KEY,
    EmpName VARCHAR(100),
    EmpSal DECIMAL(10,2)
);



/* ===============================
   STEP 2 — Create Audit Table
================================*/
CREATE TABLE Employee_Audit (
    EmpID INT,
    EmpName VARCHAR(100),
    EmpSal DECIMAL(10,2),
    Audit_Action VARCHAR(20),
    Audit_Timestamp DATETIME DEFAULT GETDATE()
);



/* ===============================
   STEP 3 — Trigger to PREVENT UPDATE
================================*/
CREATE TRIGGER prevent_update
ON Employees
INSTEAD OF UPDATE
AS
BEGIN
    RAISERROR('You can not update in this table', 16, 1);
END;


/* ===============================
   STEP 4 — Audit Trigger (INSERT & DELETE)
================================*/
CREATE TRIGGER trg_employee_audit
ON Employees
AFTER INSERT, DELETE
AS
BEGIN

    -- Log INSERT
    INSERT INTO Employee_Audit
    SELECT EmpID, EmpName, EmpSal, 'INSERT', GETDATE()
    FROM inserted;

    -- Log DELETE
    INSERT INTO Employee_Audit
    SELECT EmpID, EmpName, EmpSal, 'DELETE', GETDATE()
    FROM deleted;

END;



/* ===============================
   STEP 5 — Sample Testing Data
================================*/

-- Insert
INSERT INTO Employees(EmpName, EmpSal)
VALUES
('Kishan', 50000),
('Rahul', 45000);

-- Delete
DELETE FROM Employees WHERE EmpID = 2;

-- This will FAIL (update blocked)
UPDATE Employees
SET EmpSal = 60000
WHERE EmpID = 1;


-- Check results
SELECT * FROM Employees;
SELECT * FROM Employee_Audit;



----------------



-- 1) Products table
CREATE TABLE Products(
    ProductID INTEGER PRIMARY KEY,
    ProductName TEXT,
    Stock INTEGER
);

INSERT INTO Products VALUES
(1,'Pen',50),
(2,'Notebook',30),
(3,'Pencil',40);

-- Check initial stock
SELECT 'Before Order' AS Stage, * FROM Products;


-- 2) Orders table
CREATE TABLE Orders(
    OrderID INTEGER PRIMARY KEY IDENTITY(1,1),
    CustomerName TEXT,
    ProductID INTEGER,
    Quantity INTEGER,
    OrderTime DATETIME
);

-- 3) Trigger
CREATE TRIGGER trg_AfterOrder
ON Orders
AFTER INSERT
AS
BEGIN
    UPDATE p
    SET p.Stock = p.Stock - i.Quantity
    FROM Products p
    INNER JOIN inserted i
        ON p.ProductID = i.ProductID;
END;
-- 4) Place order
INSERT INTO Orders(CustomerName, ProductID, Quantity, OrderTime)
VALUES ('Riya', 1, 5, GETDATE());
-- Check stock after order
SELECT 'After Order' AS Stage, * FROM Products;

-- View orders
SELECT * FROM Orders;
---------------





-----------------------------------------
-- 1) Borrow Table
-----------------------------------------
CREATE TABLE Borrow(
    BorrowID INT PRIMARY KEY IDENTITY(1,1),
    StudentName VARCHAR(50),
    BookName VARCHAR(50),
    DueDate DATE
);


-----------------------------------------
-- 2) Returns Table
-----------------------------------------
CREATE TABLE Returns(
    ReturnID INT PRIMARY KEY IDENTITY(1,1),
    BorrowID INT,
    ReturnDate DATE,
    Fine INT DEFAULT 0
);


-----------------------------------------
-- 3) Trigger (AUTO FINE CALCULATION)
-----------------------------------------
CREATE TRIGGER trg_CalculateFine
ON Returns
AFTER INSERT
AS
BEGIN
    UPDATE r
    SET Fine =
        CASE
            WHEN DATEDIFF(DAY, b.DueDate, i.ReturnDate) > 0
            THEN DATEDIFF(DAY, b.DueDate, i.ReturnDate) * 10
            ELSE 0
        END
    FROM Returns r
    INNER JOIN inserted i
        ON r.ReturnID = i.ReturnID
    INNER JOIN Borrow b
        ON b.BorrowID = i.BorrowID;
END;


-----------------------------------------
-- 4) Insert Borrow Record
-----------------------------------------
INSERT INTO Borrow(StudentName, BookName, DueDate)
VALUES ('Kishan', 'DBMS Book', '2026-02-01');


-----------------------------------------
-- 5) Return book late (3 days late)
-----------------------------------------
INSERT INTO Returns(BorrowID, ReturnDate)
VALUES (1, '2026-02-04');


-----------------------------------------
-- 6) Check Result
-----------------------------------------
SELECT * FROM Borrow;
SELECT * FROM Returns;


-------------------------------------------------------------------------------------------------------



SELECT @@VERSION;


CREATE TABLE Students(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50),
    Age INT
);


select * from students;