create database script;
use script;

create table student(
id int  primary key,
name varchar(50),
m1 int ,
m2 int
);

insert into student values
(1,'mari',75,83),
(2,'raman',66,91);


create table #temp(
id int  primary key,
name varchar(50),
m1 int ,
m2 int
);

insert into #temp values
(1,'mari',75,83),
(2,'raman',66,91);


select * from student;
select * from #temp;



UPDATE student
SET m1 = m2,
    m2 = m1;



SELECT * FROM student;


UPDATE s
SET 
    s.m1 = t.m2,
    s.m2 = t.m1
FROM student s
JOIN #temp t
ON s.id = t.id;

select * from #temp;


-------------------------------------------------------------------




-- =========================
-- 2. Create Employee Table
-- =========================
CREATE TABLE Employee
(
    Id INT PRIMARY KEY,
    Name VARCHAR(50),
    Dept VARCHAR(50),
    Salary INT,
    MgrID INT NULL
);



-- =========================
-- 3. Insert Data
-- =========================
INSERT INTO Employee VALUES
(1, 'Shubhash', 'BTech', 10000, 2),
(2, 'Mani',     'MCA',   20000, NULL),
(3, 'Aditya',   'BTech', 13000, 2);



-- =========================
-- 4. View Table
-- =========================
SELECT * FROM Employee;



-- =========================
-- 5. Q1: Find Manager Name for each Employee
-- (SELF JOIN)
-- =========================
SELECT 
    e.Id,
    e.Name AS Employee,
    m.Name AS Manager
FROM Employee e
LEFT JOIN Employee m
    ON e.MgrID = m.Id;



-- =========================
-- 6. Q2: Count employees under Mani
-- =========================
SELECT COUNT(*) AS Employees_Under_Mani
FROM Employee
WHERE MgrID = (
    SELECT Id 
    FROM Employee 
    WHERE Name = 'Mani'
);


