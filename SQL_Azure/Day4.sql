-- Question :- create a table named Employee inside that 
--  create Id Name Salary Pf Age Bonus 
-- Also create another table named Canteen inside that whatever u feel like make that field , also that satisfed the given below questions
-- Q1. how much i need TO pay for candy
-- Q2.ON 23 jan how much i purchased (or on anyday)
-- Q3. amount OF candy who purchased most

create database Test1;
use Test1;

-- Employee Table
CREATE TABLE Employee(
ID int PRIMARY KEY,
Name varchar(60),
Salary int,
Pf int,
Age int,
Bonus Decimal(10,2)
);

INSERT INTO Employee VALUES
(1,'Rohan',50000,3000,24,4000),
(2,'Kishan',40000,5000,25,2300),
(3,'Anurag',70000,7000,22,2300),
(4,'Shivansh',90000,7000,21,6500),
(5,'Jyoti',55000,2000,19,4400),
(6,'Adilur',50000,3000,14,4300),
(7,'Sufiyan',52000,4000,45,6000),
(8,'Anish',120000,1500,12,1000),
(9,'Aryan',70000,2000,24,4300),
(10,'Abhishek',80000,7000,29,2000);



--Canteen Table
CREATE TABLE canteen(
OrderId int PRIMARY KEY,
EmpID int,
Item varchar(50),
Quantity int,
PricePerItem int ,
PurchaseDate date,
FOREIGN KEY (EmpID) REFERENCES Employee(Id)
);

INSERT INTO Canteen VALUES
(101, 1, 'Candy', 5, 10, '2026-01-23'),
(102, 2, 'Candy', 10, 10, '2026-01-23'),
(103, 3, 'Samosa', 2, 20, '2026-01-22'),
(104, 1, 'Candy', 3, 10, '2026-01-24'),
(105, 4, 'Candy', 8, 10, '2026-01-23'),
(106, 5, 'Burger', 2, 50, '2026-01-23'),
(107, 6, 'Candy', 6, 10, '2026-01-22'),
(108, 7, 'Candy', 12, 10, '2026-01-23'),
(109, 8, 'Samosa', 3, 20, '2026-01-24'),
(110, 9, 'Candy', 4, 10, '2026-01-23'),
(111, 10,'Candy', 9, 10, '2026-01-24');


--Q1. How much i need to pay for the candy
SELECT 
e.Name,
Sum(c.Quantity * c.PricePerItem) as TotalCandyAmount
from Employee e 
join canteen c on e.id = c.empid
where c.item = 'candy'
group by e.name;

--Q2. On 23 Jan how much I purchased?
SELECT 
    e.Name,
    SUM(c.Quantity * c.PricePerItem) AS AmountOn23Jan
FROM Employee e
JOIN Canteen c ON e.Id = c.EmpId
WHERE c.PurchaseDate = '2026-01-23'
GROUP BY e.Name;


--Q3.Amount of candy who purchased most
SELECT TOP 1
    e.Name,
    SUM(c.Quantity * c.PricePerItem) AS TotalCandyAmount
FROM Employee e
JOIN Canteen c ON e.Id = c.EmpId
WHERE c.Item = 'Candy'
GROUP BY e.Name
ORDER BY TotalCandyAmount DESC;

--------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE State_Master (
    StateID INT PRIMARY KEY,
    StateName VARCHAR(50)
);

INSERT INTO State_Master VALUES
(1,'Punjab'),
(2,'UP'),
(3,'Delhi'),
(4,'Rajasthan');

CREATE TABLE Department_Master (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);

INSERT INTO Department_Master VALUES
(1,'BCA'),
(2,'BSc'),
(3,'BCom'),
(6,'BTech CSE');

CREATE TABLE Hostel (
    RoomID INT PRIMARY KEY,
    RoomType VARCHAR(30),
    Capacity INT
);

INSERT INTO Hostel VALUES
(101,'Single',1),
(102,'Double',2),
(103,'Triple',3),
(104,'Double',2);

CREATE TABLE College_Master (
    StudentID INT PRIMARY KEY,
    Name VARCHAR(50),
    StateID INT,
    DeptID INT,
    RoomID INT,
    DOB DATE,
    Age INT,
    FOREIGN KEY (StateID) REFERENCES State_Master(StateID),
    FOREIGN KEY (DeptID) REFERENCES Department_Master(DeptID),
    FOREIGN KEY (RoomID) REFERENCES Hostel(RoomID)
);

INSERT INTO College_Master VALUES
(1,'Vaibhav',2,6,102,'2005-01-01',21),
(2,'Rohan',1,1,101,'2004-03-12',22),
(3,'Neha',3,6,103,'2005-07-08',20),
(4,'Amit',4,2,104,'2003-11-15',23),
(5,'Priya',1,3,102,'2004-05-20',21);


CREATE TABLE Book_Master (
    BookID INT PRIMARY KEY,
    BookName VARCHAR(100),
    Price INT
);

INSERT INTO Book_Master VALUES
(201,'DBMS Concepts',450),
(202,'Operating System',500),
(203,'Computer Networks',550),
(204,'Data Structures in C',400);


CREATE TABLE Library (
    LibID INT PRIMARY KEY,
    BookID INT,
    StudentID INT,
    IssueDate DATE,
    FOREIGN KEY (BookID) REFERENCES Book_Master(BookID),
    FOREIGN KEY (StudentID) REFERENCES College_Master(StudentID)
);

INSERT INTO Library VALUES
(1,201,1,'2026-01-10'),
(2,202,2,'2026-01-11'),
(3,203,3,'2026-01-12'),
(4,204,1,'2026-01-13'),
(5,202,4,'2026-01-14'),
(6,201,5,'2026-01-15');



SELECT * FROM State_Master;
SELECT * FROM Department_Master;
SELECT * FROM Hostel;
SELECT * FROM College_Master;
SELECT * FROM Book_Master;
SELECT * FROM Library;

------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create table CollegeMaster1(
Id int primary key,
Name varchar(60),
CourseID int
);


insert into collegemaster1 values
(1,'Kishan',4),
(2,'Rohan',2),
(3,'Aditya',1),
(4,'Anurag',4),
(5,'Manish',4),
(6,'Suman',1),
(7,'Tirth',2),
(8,'Tisha',4);


create table Course(
Id int primary key,
CourseName varchar(100)
);

insert into course values
(1,'Python'),
(2,'Java'),
(3,'Cpp'),
(4,'Dotnet');

-- Right Join
select 
c.name,
co.coursename
from collegemaster1 c
right join course co
on c.courseid = co.id;

--Subquery example
--1. Students enrolled in Dotnet

SELECT Name
FROM CollegeMaster1
WHERE CourseID = (
    SELECT Id 
    FROM Course 
    WHERE CourseName = 'Dotnet'
);

-- 2.Course name of student ‘Kishan’
select coursename from course
where id =  (select courseid from collegemaster1 where name='Kishan' );



