create database testt1;
use testt1;

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    PhoneNumber VARCHAR(15),
    City VARCHAR(50),
    CreatedDate DATE
);

CREATE TABLE Accounts
(
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(20), -- Savings / Current
    OpeningBalance DECIMAL(12,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    TransactionDate DATE,
    TransactionType VARCHAR(10), -- Deposit / Withdraw
    Amount DECIMAL(12,2),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE Bonus
(
    BonusID INT IDENTITY(1,1) PRIMARY KEY,
    AccountID INT,
    BonusMonth INT,
    BonusYear INT,
    BonusAmount DECIMAL(10,2),
    CreatedDate DATE,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);


INSERT INTO Customers VALUES
(1, 'Ravi Kumar', '9876543210', 'Chennai', '2023-01-10'),
(2, 'Priya Sharma', '9123456789', 'Bangalore', '2023-03-15'),
(3, 'John Peter', '9988776655', 'Hyderabad', '2023-06-20');

INSERT INTO Accounts VALUES
(101, 1, 'SB1001', 'Savings', 20000),
(102, 2, 'SB1002', 'Savings', 15000),
(103, 3, 'SB1003', 'Savings', 30000);

INSERT INTO Transactions VALUES
(1, 101, '2024-01-05', 'Deposit', 30000),
(2, 101, '2024-01-18', 'Withdraw', 5000),
(3, 101, '2024-02-10', 'Deposit', 25000),

(4, 102, '2024-01-07', 'Deposit', 20000),
(5, 102, '2024-01-25', 'Deposit', 35000),
(6, 102, '2024-02-05', 'Withdraw', 10000),

(7, 103, '2024-01-10', 'Deposit', 15000),
(8, 103, '2024-01-20', 'Withdraw', 5000);



--Question 1 – Stored Procedure (Date Range + Aggregation)
--Write a stored procedure that accepts:
--@StartDate
--@EndDate
--@AccountID
--Output:
--Total Deposited Amount during the given period
--Total Withdrawn Amount during the given period
--The procedure should return both values in a single result.

CREATE PROCEDURE GetTransactionSummary
    @StartDate DATE,
    @EndDate DATE,
    @AccountID INT
AS
BEGIN
    SELECT
        SUM(CASE WHEN TransactionType = 'Deposit' THEN Amount ELSE 0 END) AS TotalDeposited,
        SUM(CASE WHEN TransactionType = 'Withdraw' THEN Amount ELSE 0 END) AS TotalWithdrawn
    FROM Transactions
    WHERE AccountID = @AccountID
      AND TransactionDate BETWEEN @StartDate AND @EndDate;
END;





EXEC GetTransactionSummary '2024-01-01','2024-01-31',101;




--Question 2 – Monthly Bonus Update (Business Rule + Grouping)
--Bank policy:
--If an account’s total deposited amount in a month exceeds ₹50,000
--The customer is eligible for a bonus of ₹1,000
--Task:
--Identify eligible accounts month-wise
--Insert bonus records into the Bonus table
--Bonus should be credited only once per account per month



INSERT INTO Bonus (AccountID, BonusMonth, BonusYear, BonusAmount, CreatedDate)
SELECT
    t.AccountID,
    MONTH(t.TransactionDate),
    YEAR(t.TransactionDate),
    1000,
    GETDATE()
FROM Transactions t
WHERE t.TransactionType = 'Deposit'
GROUP BY t.AccountID, MONTH(t.TransactionDate), YEAR(t.TransactionDate)
HAVING SUM(t.Amount) > 50000
AND NOT EXISTS (
    SELECT 1
    FROM Bonus b
    WHERE b.AccountID = t.AccountID
      AND b.BonusMonth = MONTH(t.TransactionDate)
      AND b.BonusYear = YEAR(t.TransactionDate)
);

SELECT * FROM Bonus;




--Question 3 – Check Current Balance (Logical Calculation)
--Current balance is calculated as:
--Opening Balance
--+ Total Deposits
--- Total Withdrawals
--+ Bonus Amount (if any)
--Task:
--Write a query to display:
--CustomerName
--AccountNumber
--CurrentBalance


SELECT
    c.CustomerName,
    a.AccountNumber,

    a.OpeningBalance
    + ISNULL(SUM(CASE WHEN t.TransactionType = 'Deposit' THEN t.Amount END),0)
    - ISNULL(SUM(CASE WHEN t.TransactionType = 'Withdraw' THEN t.Amount END),0)
    + ISNULL(SUM(b.BonusAmount),0) AS CurrentBalance

FROM Accounts a
JOIN Customers c ON a.CustomerID = c.CustomerID
LEFT JOIN Transactions t ON a.AccountID = t.AccountID
LEFT JOIN Bonus b ON a.AccountID = b.AccountID
GROUP BY c.CustomerName, a.AccountNumber, a.OpeningBalance;