
CREATE DATABASE CollegeLPU;
USE CollegeLPU;

CREATE TABLE college_master (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255),
    Dob VARCHAR(255),
    pincode INT,
    address VARCHAR(255),
    gender VARCHAR(255),
    m1 INT,
    m2 INT,
    m3 INT,
    m4 INT,
    grade VARCHAR(10),
    phoneNo BIGINT
);

INSERT INTO college_master (name, Dob, pincode, address, gender, m1, m2, m3, m4, grade, phoneNo) VALUES
('Aarav Sharma','2003-05-12',144001,'LPU Campus','Male',85,78,90,88,'A',9876543210),
('Priya Verma','2003-07-22',144002,'Phagwara','Female',92,89,95,91,'A+',9876543211),
('Rohit Kumar','2002-11-10',144003,'Jalandhar','Male',70,75,72,68,'B',9876543212),
('Neha Singh','2003-02-18',144004,'Amritsar','Female',88,84,86,90,'A',9876543213),
('Karan Patel','2002-09-05',144005,'Ludhiana','Male',60,65,58,62,'C',9876543214),
('Simran Kaur','2003-03-15',144006,'Patiala','Female',95,94,96,93,'A+',9876543215),
('Vivek Gupta','2002-12-01',144007,'Chandigarh','Male',78,82,80,76,'B+',9876543216),
('Anjali Mehta','2003-06-30',144008,'Delhi','Female',90,88,92,89,'A+',9876543217),
('Rahul Das','2002-08-19',144009,'Kolkata','Male',55,60,58,57,'C',9876543218),
('Pooja Nair','2003-01-25',144010,'Kerala','Female',87,85,88,86,'A',9876543219),
('Raman', '2003-04-10', 144011, 'LPU Campus', 'Male', 80, 85, 78, 82, 'A', 9876543220);


CREATE TABLE boys_hostel (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    roomNo INT,
    collegeId BIGINT,
    FOREIGN KEY (collegeId) REFERENCES college_master(id)
);

INSERT INTO boys_hostel (roomNo, collegeId) VALUES
(1, 1),
(2, 3),
(3, 5);

CREATE TABLE girl_hostel (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    roomNo INT,
    collegeId BIGINT,
    FOREIGN KEY (collegeId) REFERENCES college_master(id)
);

INSERT INTO girl_hostel (roomNo, collegeId) VALUES
(1, 2),
(2, 4),
(3, 6);

CREATE TABLE book_master (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    bookName VARCHAR(255),
    authorName VARCHAR(255),
    code VARCHAR(255),
    price BIGINT
);

INSERT INTO book_master (bookName, authorName, code, price) VALUES
('DBMS Concepts','Navathe','B001',550),
('Operating System','Galvin','B002',650),
('Computer Networks','Tanenbaum','B003',600),
('Java Programming','Herbert Schildt','B004',500),
('Python Basics','Guido','B005',450),
('Data Structures','Mark Allen','B006',480),
('Software Engineering','Pressman','B007',700);

CREATE TABLE library (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    bookId BIGINT,
    takenBy BIGINT,
    issueDate VARCHAR(255),
    FOREIGN KEY (bookId) REFERENCES book_master(id),
    FOREIGN KEY (takenBy) REFERENCES college_master(id)
);

INSERT INTO library (bookId, takenBy, issueDate) VALUES
(1, 1, '2026-01-10'),
(3, 2, '2026-01-12'),
(5, 4, '2026-01-15'),
(7, 6, '2026-01-18'),
(4, 3, '2026-01-20'),
(2, 11, '2026-01-22'); 

SELECT * FROM college_master;
SELECT * FROM boys_hostel;
SELECT * FROM girl_hostel;
SELECT * FROM book_master;
SELECT * FROM library;



--1) Phone numbers of students in Room No = 1 (both hostels)

SELECT c.phoneNo
FROM college_master c
JOIN boys_hostel b ON c.id = b.collegeId
WHERE b.roomNo = 1

UNION

SELECT c.phoneNo
FROM college_master c
JOIN girl_hostel g ON c.id = g.collegeId
WHERE g.roomNo = 1;


--2) Room numbers of all Male / Female students

-- Male students rooms
SELECT b.roomNo, c.name
FROM college_master c
JOIN boys_hostel b ON c.id = b.collegeId;

-- Female students rooms
SELECT g.roomNo, c.name
FROM college_master c
JOIN girl_hostel g ON c.id = g.collegeId;


-- 3) How many hostel students scored 100  (Checking any mark = 100)

SELECT COUNT(*) AS StudentsScored100
FROM college_master c
WHERE (c.m1=100 OR c.m2=100 OR c.m3=100 OR c.m4=100)
AND c.id IN (
    SELECT collegeId FROM boys_hostel
    UNION
    SELECT collegeId FROM girl_hostel
);


-- 4) Students staying in Room No = 2 (full info)
SELECT c.*
FROM college_master c
JOIN boys_hostel b ON c.id = b.collegeId
WHERE b.roomNo = 2

UNION

SELECT c.*
FROM college_master c
JOIN girl_hostel g ON c.id = g.collegeId
WHERE g.roomNo = 2;

-- 5) Average M1 marks of Room No = 2 students

SELECT AVG(c.m1) AS Avg_M1_Room2
FROM college_master c
WHERE c.id IN (
    SELECT collegeId FROM boys_hostel WHERE roomNo = 2
    UNION
    SELECT collegeId FROM girl_hostel WHERE roomNo = 2
);



--1) Print the student name who has taken the Java book from the library
SELECT c.name
FROM college_master c
JOIN library l ON c.id = l.takenBy
JOIN book_master b ON l.bookId = b.id
WHERE b.bookName = 'Java Programming';

-- 2) How many books taken by the person who scored 100 in any one subject
SELECT COUNT(l.id) AS BooksTaken
FROM library l
JOIN college_master c ON l.takenBy = c.id
WHERE c.m1 = 100 
   OR c.m2 = 100 
   OR c.m3 = 100 
   OR c.m4 = 100;


-- 3) How many students in Room No 1 have taken books from library
SELECT COUNT(*) AS StudentsInRoom1_TakenBooks
FROM library l
WHERE l.takenBy IN (
    SELECT collegeId FROM boys_hostel WHERE roomNo = 1
    UNION
    SELECT collegeId FROM girl_hostel WHERE roomNo = 1
);


-- 4) Which department students have taken the Python book
SELECT 
CASE 
   WHEN c.id IN (SELECT collegeId FROM boys_hostel) THEN 'Boys Hostel'
   WHEN c.id IN (SELECT collegeId FROM girl_hostel) THEN 'Girls Hostel'
END AS Department
FROM college_master c
JOIN library l ON c.id = l.takenBy
JOIN book_master b ON l.bookId = b.id
WHERE b.bookName = 'Python Basics';


-- 5) Print the phone number of the student who took the Java book
SELECT c.phoneNo
FROM college_master c
JOIN library l ON c.id = l.takenBy
JOIN book_master b ON l.bookId = b.id
WHERE b.bookName = 'Java Programming';



-- 1) List all books taken by Raman

SELECT b.bookName
FROM college_master c
JOIN library l ON c.id = l.takenBy
JOIN book_master b ON l.bookId = b.id
WHERE c.name = 'Raman';

-- 2) Print the price of the book(s) taken by Raman

SELECT b.bookName, b.price
FROM college_master c
JOIN library l ON c.id = l.takenBy
JOIN book_master b ON l.bookId = b.id
WHERE c.name = 'Raman';
