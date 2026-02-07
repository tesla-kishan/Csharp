create database Duplicate;
use Duplicate;

--------------------------------------------
-- CREATE TABLE
--------------------------------------------
CREATE TABLE Users (
    UserId INT,
    UserName VARCHAR(50),
    Email VARCHAR(100)
);

--------------------------------------------
-- INSERT SAMPLE DATA
--------------------------------------------
INSERT INTO Users VALUES
(1, 'Amit',  'amit@gmail.com'),
(2, 'Ravi',  'ravi@gmail.com'),
(3, 'Neha',  'neha@gmail.com'),
(4, 'Pooja', 'amit@gmail.com'),
(5, 'Rahul', 'ravi@gmail.com'),
(6, 'Ankit', 'ankit@gmail.com');

--------------------------------------------
-- VIEW DATA
--------------------------------------------
SELECT * FROM Users;

--------------------------------------------
-- FIND DUPLICATE EMAILS WITH COUNT
--------------------------------------------
SELECT 
    Email,
    COUNT(*) AS DuplicateCount
FROM Users
GROUP BY Email
HAVING COUNT(*) > 1;
