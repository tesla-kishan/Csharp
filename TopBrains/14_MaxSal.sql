CREATE database maxsalary;
use maxsalary;


CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    Name VARCHAR(50),
    Dept VARCHAR(50),
    Salary INT
);

INSERT INTO Employees VALUES
(1, 'Ram', 'IT', 50000),
(2, 'Sam', 'IT', 70000),
(3, 'Rita', 'HR', 40000),
(4, 'Tina', 'HR', 60000),
(5, 'Mohan', 'Sales', 45000),
(6, 'Karan', 'Sales', 30000);


SELECT e.Dept, e.Name, e.Salary
FROM Employees e
JOIN (
    SELECT Dept, MAX(Salary) AS MaxSalary
    FROM Employees
    GROUP BY Dept
) m
ON e.Dept = m.Dept
AND e.Salary = m.MaxSalary;

