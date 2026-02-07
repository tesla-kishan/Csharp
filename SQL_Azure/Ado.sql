create database Ado;
use Ado;


CREATE TABLE CollegeMaster
(
    StdId INT IDENTITY PRIMARY KEY,
    StdName VARCHAR(50),
    Dept VARCHAR(50),
    Gender CHAR(1)
);

INSERT INTO CollegeMaster VALUES
('Rahul', 'Computer Science', 'M'),
('Anita', 'Computer Science', 'F'),
('Amit', 'Mechanical', 'M'),
('Sneha', 'Computer Science', 'F');

CREATE PROC sp_getStdByGenderDept
    @Gender CHAR(1),
    @Dept VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM CollegeMaster
    WHERE Gender = @Gender
      AND Dept = @Dept;
END;

EXEC sp_getStdByGenderDept 'M', 'Computer Science';

------------------------------------------------------------------------------------------------------------------------------------


CREATE PROC sp_getStudentCountByGender
    @Gender CHAR(1)
AS
BEGIN
    SELECT COUNT(*) AS StudentCount
    FROM CollegeMaster
    WHERE Gender = @Gender;
END;


EXEC sp_getStudentCountByGender 'M';





