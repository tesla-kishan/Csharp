CREATE database Day5;
use Day5;

-- Step 1: Create table first
CREATE TABLE CollegeMaster1 (
    Id INT PRIMARY KEY,
    Name VARCHAR(60),
    CourseID INT
);


-- Step 2: Insert sample data
INSERT INTO CollegeMaster1 VALUES
(1,'Kishan',4),
(2,'Rohan',2),
(3,'Aditya',1),
(4,'Anurag',4),
(5,'Manish',4),
(6,'Suman',1),
(7,'Tirth',2),
(8,'Tisha',4);



CREATE PROCEDURE GetAllStudents
AS
BEGIN
    SELECT * FROM CollegeMaster1;
END;

EXEC GetAllStudents;

------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Write a stored procedure to print all hostel students name
-- write a stored procedure to print all the hostel students name who is staying in room no. 3



CREATE TABLE HostelStudents (
    StudentID INT PRIMARY KEY,
    StudentName VARCHAR(50),
    RoomNo INT
);

INSERT INTO HostelStudents VALUES
(1,'Kishan',3),
(2,'Rohan',2),
(3,'Aditya',3),
(4,'Anurag',1),
(5,'Tisha',3);


-- 1. Stored Procedure to Print All Hostel Students Name
CREATE PROCEDURE GetAllHostelStudents
AS
BEGIN
    SELECT StudentName 
    FROM HostelStudents;
END;


EXEC GetAllHostelStudents;


--2. Stored Procedure to Print Hostel Students Staying in Room No. 3

CREATE PROCEDURE GetStudentsByRoom3
AS
BEGIN
    SELECT StudentName
    FROM HostelStudents
    WHERE RoomNo = 3;
END;

EXEC GetStudentsByRoom3;

--Instead of fixing room number, we pass it dynamically.
CREATE PROCEDURE GetStudentsByRoom
    @RoomNo INT
AS
BEGIN
    SELECT StudentName
    FROM HostelStudents
    WHERE RoomNo = @RoomNo;
END;


EXEC GetStudentsByRoom 3;
EXEC GetStudentsByRoom 2;


--Stored Procedure using INNER JOIN
CREATE PROCEDURE GetStudentsByRoomm
    @RoomNo INT
AS
BEGIN
    SELECT H.StudentName, 
           R.HostelName, 
           H.RoomNo
    FROM HostelStudents H
    INNER JOIN RoomDetails R
        ON H.RoomNo = R.RoomNo
    WHERE H.RoomNo = @RoomNo;
END;


EXEC GetStudentsByRoom 3;

------------------------------------------------------------------------------------------------


--write a stored procedure to insert the new hostel student if the hostel student count is less than 5
CREATE PROCEDURE InsertHostelStudentIfSpace
    @StudentID INT,
    @StudentName VARCHAR(50),
    @RoomNo INT
AS
BEGIN
    DECLARE @StudentCount INT;

    -- Count total hostel students
    SELECT @StudentCount = COUNT(*) FROM HostelStudents;

    -- Check condition
    IF @StudentCount < 5
    BEGIN
        INSERT INTO HostelStudents(StudentID, StudentName, RoomNo)
        VALUES(@StudentID, @StudentName, @RoomNo);

        PRINT 'Student Inserted Successfully';
    END
    ELSE
    BEGIN
        PRINT 'Hostel is Full! Cannot Insert Student';
    END
END;


EXEC InsertHostelStudentIfSpace 6, 'Rahul', 2;


--write a stored procedure to check how many students scored 100 in any paper
--if less than 4 students than update 100 marks to punjab and up to m2


CREATE TABLE StudentMarks (
    StudentID INT PRIMARY KEY,
    StudentName VARCHAR(50),
    State VARCHAR(30),
    M1 INT,
    M2 INT,
    M3 INT
);

INSERT INTO StudentMarks VALUES
(1,'Kishan','Punjab',95,88,90),
(2,'Rohan','UP',85,76,80),
(3,'Aditya','Bihar',100,78,85),
(4,'Tisha','Delhi',92,100,89),
(5,'Manish','Punjab',70,60,75);


ALTER TABLE StudentMarks
ADD CONSTRAINT CHK_MarksRange
CHECK (M1 BETWEEN 0 AND 100 
       AND M2 BETWEEN 0 AND 100 
       AND M3 BETWEEN 0 AND 100);



CREATE PROCEDURE UpdateMarksIfLessThan4Toppers
AS
BEGIN
    DECLARE @TopperCount INT;

    -- Count students who scored 100 in any paper
    SELECT @TopperCount = COUNT(*)
    FROM StudentMarks
    WHERE M1 = 100 OR M2 = 100 OR M3 = 100;

    -- If less than 4 students have 100
    IF @TopperCount < 4
    BEGIN
        UPDATE StudentMarks
        SET M2 = 100
        WHERE State IN ('Punjab','UP');

        PRINT 'Marks Updated: Punjab and UP students given 100 in M2';
    END
    ELSE
    BEGIN
        PRINT 'Already 4 or more toppers exist. No update needed';
    END
END;

EXEC UpdateMarksIfLessThan4Toppers;



--insert one hostel student record through stored procedure but room number should be limited to 100

CREATE PROCEDURE InsertHostelStudentWithRoomLimit
    @StudentID INT,
    @StudentName VARCHAR(50),
    @RoomNo INT
AS
BEGIN
    -- Check room limit
    IF @RoomNo <= 100
    BEGIN
        INSERT INTO HostelStudents(StudentID, StudentName, RoomNo)
        VALUES(@StudentID, @StudentName, @RoomNo);

        PRINT 'Student Inserted Successfully';
    END
    ELSE
    BEGIN
        PRINT 'Room Number Exceeds Limit! Insert Failed';
    END
END;

EXEC InsertHostelStudentWithRoomLimit 6, 'Rahul', 102;

select * from HostelStudents;

ALTER TABLE HostelStudents
ADD CONSTRAINT CHK_RoomLimit
CHECK (RoomNo <= 100);


--constraint

CREATE TABLE college_master (
    student_id INT,
    full_name VARCHAR(50),
    gender VARCHAR(10),
    phone_no VARCHAR(10),
    department VARCHAR(10),
    year_of_study INT,
    m1_mark INT,
    total_marks INT
);



ALTER TABLE college_master
ADD
    CONSTRAINT c1 CHECK (student_id > 0),                  -- Student ID must be positive
    CONSTRAINT c2 CHECK (LEN(full_name) > 0),              -- Name cannot be empty
    CONSTRAINT c3 CHECK (gender IN ('Male','Female')),    -- Gender allowed values only
    CONSTRAINT c4 CHECK (LEN(phone_no) = 10),             -- Phone number must be 10 digits
    CONSTRAINT c5 CHECK (year_of_study BETWEEN 1 AND 4),  -- Year must be 1 to 4
    CONSTRAINT c6 CHECK (m1_mark BETWEEN 0 AND 100),      -- Marks range validation
    CONSTRAINT c7 CHECK (total_marks BETWEEN 0 AND 500),  -- Total marks limit
    CONSTRAINT c8 CHECK (department IN ('CSE','ECE','IT','ME')); -- Valid departments

--Valid Insert (Will Work)
INSERT INTO college_master VALUES
(7,'newname','Male','1234567890','CSE',4,98,400);


-- Invalid Insert (Will Fail)
INSERT INTO college_master VALUES
(7,'Test','Male','123','CSE',5,150,700);

select * from college_master;

--Calculate Total Days Between Two Dates
SELECT DATEDIFF(DAY, '2003-12-01', GETDATE()) AS TotalDays;
--Example with Custom Start and End Date
SELECT DATEDIFF(DAY, '2004-06-15', '2026-01-28') AS TotalDays;
--Show Start Date, End Date, and Total Days Together
SELECT 
    '2004-06-15' AS StartDate,
    GETDATE() AS EndDate,
    DATEDIFF(DAY, '2004-06-15', GETDATE()) AS TotalDays;


---------------------------------------------------------------------------

create table Data(
id int primary key,
name varchar(60),
DOB DATE
);

INSERT INTO Data VALUES
(1,'karan','2005-04-05'),
(2,'x','2005-11-06'),
(3,'y','2004-04-02'),
(4,'z','2005-03-11');

SELECT *
FROM Data
WHERE MONTH(DOB) = 4;

DECLARE @Month INT = 4;
SELECT *
FROM Data
WHERE MONTH(DOB) = @Month;


CREATE PROCEDURE GetStudentsByBirthMonth
    @Month INT
AS
BEGIN
    SELECT *
    FROM Data
    WHERE MONTH(DOB) = @Month;
END;

EXEC GetStudentsByBirthMonth 4;
