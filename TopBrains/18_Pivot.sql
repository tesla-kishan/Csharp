create database qpivot;
use qpivot;

CREATE TABLE Attendance (
    EmpId INT,
    MonthName VARCHAR(10),
    TotalPresent INT
);



INSERT INTO Attendance VALUES
(101, 'Jan', 20),
(101, 'Feb', 18),
(101, 'Mar', 22),
(102, 'Jan', 21),
(102, 'Feb', 20),
(102, 'Mar', 19),
(103, 'Jan', 23),
(103, 'Feb', 21),
(103, 'Mar', 20);

SELECT * FROM Attendance;



SELECT EmpId,
       ISNULL([Jan], 0) AS Jan,
       ISNULL([Feb], 0) AS Feb,
       ISNULL([Mar], 0) AS Mar
FROM
(
    SELECT EmpId, MonthName, TotalPresent
    FROM Attendance
) AS SourceTable
PIVOT
(
    SUM(TotalPresent)
    FOR MonthName IN ([Jan], [Feb], [Mar])
) AS PivotTable
ORDER BY EmpId;