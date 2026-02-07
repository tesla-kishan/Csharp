CREATE database Day6;
use Day6;
--ALTER DATABASE Day7 MODIFY NAME = Day6;
SELECT name  FROM sys.tables;

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


CREATE TABLE BoysHostel (
    BID INT PRIMARY KEY IDENTITY(1,1),
    Roomno INT,
    CollegeId INT,
    FOREIGN KEY (CollegeId) REFERENCES CollegeMaster(ID)
);


CREATE OR ALTER PROC dbo.uspGetHostelStudents
AS
BEGIN
    DECLARE @ID INT;

    BEGIN TRY
        BEGIN TRANSACTION t1;

        -- Step 1: Insert into CollegeMaster
        INSERT INTO CollegeMaster
        ([Name], PhoneNo, Pincode, [Address], Degree, Gender, M1, M2, M3, M4)
        VALUES
        ('Shh', 8963, 23012, 'HP', 'BCA', 'Female', 70, 80, 90, 60);

        -- Step 2: Get auto-generated ID
        SET @ID = SCOPE_IDENTITY();

        -- Step 3: Insert into BoysHostel using fetched ID
        INSERT INTO BoysHostel (Roomno, CollegeId)
        VALUES (333, @ID);

        -- Step 4: Check insert success
        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION t1;
            PRINT 'ROLLBACK DONE';
            RETURN;
        END

        -- Step 5: Commit if everything successful
        COMMIT TRANSACTION t1;
        PRINT 'TRANSACTION COMMITTED SUCCESSFULLY';

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION t1;

        PRINT 'ROLLBACK DONE - ERROR OCCURRED';
    END CATCH
END;


EXEC dbo.uspGetHostelStudents;

INSERT INTO BoysHostel(Roomno, CollegeId)
VALUES(222, 999);   -- 999 doesn't exist

SELECT * FROM CollegeMaster;
SELECT * FROM BoysHostel;


CREATE TABLE Hostel3 (
    RoomNo INT,
    CollegeId INT
);
INSERT INTO Hostel3 VALUES (101,1), (102,1);
select * from hostel3;

-- Insert all records from Hostel3 into BoysHostel
INSERT INTO dbo.BoysHostel (Roomno, CollegeId)
SELECT RoomNo, CollegeId
FROM dbo.Hostel3;

-- Display BoysHostel after insertion
SELECT * FROM dbo.BoysHostel;



--------------------------------------------------------------------------------------------------------------

--UNION

-- Punjab Sports Table
CREATE TABLE PunjabSports (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50),
    SportsName VARCHAR(50)
);

-- Haryana Sports Table
CREATE TABLE HaryanaSports (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50),
    SportsName VARCHAR(50)
);

-- Punjab Players
INSERT INTO PunjabSports (Name, SportsName) VALUES
('Rohit', 'Basketball'),
('Kishan', 'Cricket'),
('Aman', 'Football'),
('Rohit', 'Basketball');

-- Haryana Players
INSERT INTO HaryanaSports (Name, SportsName) VALUES
('Neha', 'Cricket'),
('Pooja', 'Football'),
('Vikas', 'Basketball');

--Removes duplicate rows
SELECT * FROM PunjabSports
UNION
SELECT * FROM HaryanaSports;


--UNION ALL (includes duplicates)
SELECT * FROM PunjabSports
UNION ALL
SELECT * FROM HaryanaSports;


--Removes duplicate rows
SELECT Name,SportsName FROM PunjabSports
UNION
SELECT Name,SportsName FROM HaryanaSports;


--UNION ALL (includes duplicates)
SELECT Name,SportsName FROM PunjabSports
UNION ALL
SELECT Name,SportsName FROM HaryanaSports;


------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CollegeData (
    Id INT PRIMARY KEY,
    Name VARCHAR(50)
);
INSERT INTO CollegeData VALUES
(1, 'KISHAN'),
(2, 'ROHAN'),
(3, 'KARAN'),
(4, 'AMIT'),
(5, 'PRIYA'),
(6, 'RAVI');


select Id,SUBSTRING(Name,1,3) AS Short_Name from CollegeData;

select Id,Left(Name,3) AS Short_Name from CollegeData;

SELECT LEFT(Name, CHARINDEX('R', Name)) AS Substring_Till_R FROM CollegeData;

SELECT Id,
CASE 
    WHEN CHARINDEX('R', Name) > 0
    THEN SUBSTRING(Name, CHARINDEX('R', Name), LEN(Name))
    ELSE Name
END AS From_R_To_End
FROM CollegeData;

