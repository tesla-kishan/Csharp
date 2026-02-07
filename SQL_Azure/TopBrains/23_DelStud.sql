

--------------------------------------------
-- CREATE DATABASE
--------------------------------------------
CREATE DATABASE deletee;

USE deletee;


--------------------------------------------
-- CREATE TABLES
--------------------------------------------
CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(50)
);

CREATE TABLE Marks (
    mark_id INT IDENTITY(1,1) PRIMARY KEY,
    student_id INT,
    marks INT,
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
);

--------------------------------------------
-- INSERT DATA
--------------------------------------------
INSERT INTO Students VALUES
(1, 'Amit'),
(2, 'Rahul'),
(3, 'Sneha'),
(4, 'Priya'),
(5, 'Karan');

INSERT INTO Marks (student_id, marks) VALUES
(1, 85),
(3, 90),
(5, 78);

--------------------------------------------
-- DELETE STUDENTS WITHOUT MARKS (CORRECT)
--------------------------------------------
DELETE FROM Students
WHERE student_id NOT IN (
    SELECT student_id FROM Marks
);

--------------------------------------------
-- CHECK RESULT
--------------------------------------------
SELECT * FROM Students;
