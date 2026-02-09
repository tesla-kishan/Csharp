create database day15;
use day15;



CREATE TABLE Students
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    Age INT
);


CREATE PROCEDURE sp_InsertStudent
    @Name VARCHAR(50),
    @Age INT
AS
BEGIN
    INSERT INTO Students(Name, Age)
    VALUES (@Name, @Age)
END


SELECT * FROM Students;


-------------------------------


CREATE TABLE HostelStudents
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Category VARCHAR(20),   
    IsHostel BIT            
);


INSERT INTO HostelStudents (Name, Age, Category, IsHostel) VALUES
('Rahul', 21, 'General', 1),
('Aman', 22, 'OBC', 1),
('Neha', 20, 'General', 1),
('Priya', 23, 'SC', 1),
('Rohit', 24, 'General', 1),
('Suman', 22, 'OBC', 1),
('Karan', 21, 'General', 0),
('Anjali', 20, 'SC', 0);

SELECT * FROM HostelStudents;


CREATE PROCEDURE sp_GetHostelStudentCount
AS
BEGIN
    SELECT COUNT(*) FROM HostelStudents WHERE IsHostel = 1;
END;


CREATE PROCEDURE sp_DeleteHostelStudentsByCategory
    @Category VARCHAR(20)
AS
BEGIN
    DELETE FROM HostelStudents
    WHERE IsHostel = 1 AND Category = @Category;
END;


CREATE PROCEDURE sp_ViewAllStudents
AS
BEGIN
    SELECT * FROM HostelStudents;
END;


exec sp_ViewAllStudents;

SELECT Id, Name, IsHostel
FROM HostelStudents
WHERE IsHostel = 1;

SELECT COUNT(*) FROM HostelStudents WHERE IsHostel = 1;


delete from HostelStudents where IsHostel=0;

INSERT INTO HostelStudents (Name, Age, Category, IsHostel) VALUES
('Mari', 21, 'General', 1),
('Maman', 22, 'OBC', 0),
('Babban', 20, 'General', 1),
('Saban', 23, 'SC', 0);


---------------------------------------------------------------------


CREATE FUNCTION dbo.FnSquare
(
    @num INT
)
RETURNS INT
AS
BEGIN
    RETURN @num * @num
END


SELECT dbo.FnSquare(6);



------------------------------------------------


CREATE PROCEDURE sp_GetStudents
AS
BEGIN
    SELECT * FROM Students;
END;


exec sp_GetStudents;
