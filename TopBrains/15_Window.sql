create database Window_15;
use Window_15;


-- 1) Create table
CREATE TABLE Sales (
    ProductId INT,
    SaleMonth DATE,
    Amount INT
);

-- 2) Insert sample data
INSERT INTO Sales (ProductId, SaleMonth, Amount) VALUES
(1, '2024-01-01', 100),
(1, '2024-02-01', 150),
(1, '2024-03-01', 200),
(2, '2024-01-01', 80),
(2, '2024-02-01', 120),
(2, '2024-03-01', 160);

-- 3) View original data
SELECT * FROM Sales
ORDER BY ProductId, SaleMonth;

-- 4) Calculate cumulative (running) total using window function
SELECT
    ProductId,
    SaleMonth,
    Amount,
    SUM(Amount) OVER (
        PARTITION BY ProductId
        ORDER BY SaleMonth
        ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
    ) AS CumulativeSales
FROM Sales
ORDER BY ProductId, SaleMonth;