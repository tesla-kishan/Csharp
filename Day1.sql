--SELECT @@VERSION;

-- create database CollegeDB;
-- use collegedb;
-- SELECT DB_NAME();

-- select * from Table_1;

-- CREATE TABLE Students (
--     Id INT PRIMARY KEY,
--     Name VARCHAR(50),
--     Age INT
-- );

-- select * from Students;

-- INSERT INTO Students (Id, Name, Age)
-- VALUES
-- (2, 'Rahul Sharma', 22),
-- (3, 'Aman Verma', 20),
-- (4, 'Neha Singh', 23);


-- select * from Students;



-- create table Departments(
--     DeptId int primary key,
--     DeptNAme varchar(50)
-- );

-- select * from Departments;

-- insert into Departments(DeptId,DeptNAme)VALUES
-- (1,'CSE'),
-- (2, 'ECE'),
-- (3, 'ME');

-- select * from Departments;


-- CREATE TABLE Student1 (
--     StudentId INT PRIMARY KEY,
--     StudentName VARCHAR(50),
--     DeptId INT,
--     CONSTRAINT FK_Students_Departments
--     FOREIGN KEY (DeptId)
--     REFERENCES Departments(DeptId)
-- );

-- INSERT INTO Student1 (StudentId, StudentName, DeptId)
-- VALUES
-- (101, 'Kishan Lal', 1),
-- (102, 'Rahul Sharma', 2);

-- SELECT * FROM Departments;
-- SELECT * FROM Students;