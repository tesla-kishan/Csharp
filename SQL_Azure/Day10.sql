create database day10;
use day10;


--A clustered index physically sorts the actual table data based on a column.

CREATE TABLE Student(
   id INT ,
   name VARCHAR(50)
);

INSERT INTO Student (id, name) VALUES
(5, 'Amit'),
(2, 'Rahul'),
(9, 'Sneha'),
(1, 'Kishan'),
(7, 'Priya'),
(4, 'Vikas'),
(6, 'Anjali'),
(3, 'Rohit'),
(10, 'Neha'),
(8, 'Arjun');
INSERT INTO Student VALUES (15, 'Test1');
INSERT INTO Student VALUES (0, 'Test2');
INSERT INTO Student VALUES (12, 'Test3');

CREATE CLUSTERED INDEX idx_id
ON Student(id);

DROP INDEX idx_id ON Student;

SELECT * FROM Student;


--  By default = non-clustered

CREATE NONCLUSTERED INDEX idx_name
ON Student(name);

CREATE INDEX idx_student_name
ON Student(name);


SELECT * FROM Student WHERE name='Kishan'; -- fast



-----------------------------------------------------------------------------------------------------------------------
--trigger
--A Trigger is a special stored procedure that runs automatically when an event happens on a table.
--Events:
--INSERT
--UPDATE
--DELETE

--Super easy real-life example
--Think like:
--Bank account
--If money withdrawn → send SMS automatically
--You don’t call SMS manually.
--DB triggers it.
--That’s Trigger.


CREATE TRIGGER trg_after_insert
ON Student
AFTER INSERT
AS
BEGIN
   PRINT 'Student inserted';
END;



CREATE TRIGGER trg_no_delete
ON Student
INSTEAD OF DELETE
AS
BEGIN
   PRINT 'Delete not allowed';
END;


DELETE FROM Student WHERE id=1;

--------------------------------------------------------------------------------------------------------------------



