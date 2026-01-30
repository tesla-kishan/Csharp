CREATE DATABASE Day8;
use Day8;

SELECT name FROM sys.databases;


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE CollegeMaster (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50),
    PhoneNo BIGINT,
    Pincode INT,
    [Address] VARCHAR(100),
    Degree VARCHAR(20),
    Gender VARCHAR(10),
    M1 INT,
    M2 INT,
    M3 INT,
    M4 INT
);

INSERT INTO CollegeMaster
(Name, PhoneNo, Pincode, Address, Degree, Gender, M1, M2, M3, M4)
VALUES
('Kishan', 8084969846, 144411, 'Phagwara, Punjab', 'BTech', 'Male', 78, 82, 75, 80),

('Rohan', 9123456789, 110001, 'Delhi', 'BCA', 'Male', 65, 70, 68, 72),

('Tisha', 9988776655, 400001, 'Mumbai', 'BCom', 'Female', 88, 90, 85, 92),

('Aditya', 9090909090, 560001, 'Bangalore', 'BTech', 'Male', 74, 76, 79, 81);



CREATE OR ALTER FUNCTION HighM2Marks()
RETURNS INT
AS
BEGIN
    DECLARE @maxm2 INT;

    SELECT @maxm2 = MAX(M2)
    FROM CollegeMaster;

    RETURN @maxm2;
END;


SELECT dbo.HighM2Marks() AS Highest_M2;

--Highest M2 with student name (query)
SELECT Name, M2
FROM CollegeMaster
WHERE M2 = dbo.HighM2Marks();


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


--Local Temporary Table

CREATE TABLE #StudentTemp (
    ID INT,
    Name VARCHAR(50),
    Marks INT
);

INSERT INTO #StudentTemp VALUES
(1, 'Kishan', 85),
(2, 'Rohan', 78);

SELECT * FROM #StudentTemp;



-- Global Temporary Table (##TempTable)

CREATE TABLE ##StudentGlobal (
    ID INT,
    Name VARCHAR(50),
    Marks INT
);


INSERT INTO ##StudentGlobal VALUES
(1, 'Aman', 90),
(2, 'Neha', 88);

SELECT * FROM ##StudentGlobal;

--Deleted when all sessions close

---------------------------------------------------------------------------------------------------------------------

















