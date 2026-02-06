create database deletee;
use deletee;

-- create tables
CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(50)
);

CREATE TABLE Marks (
    mark_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT,
    marks INT,
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
);

-- insert data
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

-- delete students without marks
DELETE FROM Students
WHERE student_id NOT IN (
    SELECT student_id FROM Marks
);


-- check result
SELECT * FROM Students;

