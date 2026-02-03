create database day9;
use day9;

CREATE TABLE StudentMarks (
    Id INT,
    Department VARCHAR(20),
    M2 INT
);


INSERT INTO StudentMarks VALUES
(1, 'MCA', 78),
(2, 'BE', 85),
(3, 'MCA', 92),
(4, 'BE', 75),
(5, 'MCA', 78);


select department, AVG(m2) as AverageMarks
from Studentmarks
group by department;


-- find the 3rd max m2 marks
select DISTINCT m2 from studentmarks
order by m2 desc
offset 2 rows
fetch next 1 row only



-- write 1 common type exoression which department has highest marks score

select top 1 department, SUM(m2) as TotalSum
from studentmarks
group by department
order by TotalSum desc;

-- CTE to find department with highest M2 marks
WITH DeptMaxMarks AS (
    SELECT Department, MAX(M2) AS MaxMarks
    FROM StudentMarks
    GROUP BY Department
)
SELECT Department, MaxMarks
FROM DeptMaxMarks
WHERE MaxMarks = (
    SELECT MAX(MaxMarks)
    FROM DeptMaxMarks
);

--CTE to find department with highest average M2 marks
WITH DeptAvgMarks AS (
    SELECT Department, AVG(M2) AS AvgMarks
    FROM StudentMarks
    GROUP BY Department
)
SELECT TOP 1 Department, AvgMarks
FROM DeptAvgMarks
ORDER BY AvgMarks DESC;

------------------------------------------------------------------------------------------------------------------------









