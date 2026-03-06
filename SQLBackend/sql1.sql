USE master;
GO

CREATE DATABASE capgemini;
GO

USE capgemini;
GO

CREATE TABLE Students
(
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(120) NOT NULL,
    Email NVARCHAR(180) NOT NULL UNIQUE,
    Phone NVARCHAR(15),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    JoinDate DATE NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO


CREATE TABLE Courses
(
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    DurationDays INT NOT NULL,
    Fee DECIMAL(10,2) NOT NULL,
    Level NVARCHAR(30) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

CREATE TABLE Enrollments
(
    EnrollmentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrollDate DATE NOT NULL,
    PaymentStatus NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    PaidAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Enrollments_Students
        FOREIGN KEY (StudentId) REFERENCES Students(StudentId),

    CONSTRAINT FK_Enrollments_Courses
        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),

    CONSTRAINT UQ_Student_Course UNIQUE (StudentId, CourseId)
);
GO


CREATE TABLE tblLog
(
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    Info VARCHAR(2000),

    CONSTRAINT FK_tblLog_Students
        FOREIGN KEY (StudentId) REFERENCES Students(StudentId)
);
GO


INSERT INTO Students (FullName, Email, Phone, JoinDate)
VALUES
('Aman Verma', 'aman@capgemini.com', '9876543210', '2026-02-01'),
('Priya Singh', 'priya@capgemini.com', '9876543211', '2026-02-05'),
('Rohan Mehta', 'rohan@capgemini.com', '9876543212', '2026-02-10'),
('Sneha Kapoor', 'sneha@capgemini.com', '9876543213', '2026-02-12');
GO


INSERT INTO Courses (Title, DurationDays, Fee, Level)
VALUES
('ASP.NET Core MVC', 25, 8500, 'Beginner'),
('Entity Framework Core', 18, 7500, 'Intermediate'),
('Microservices with .NET', 30, 12000, 'Advanced'),
('Azure DevOps Fundamentals', 15, 6500, 'Intermediate');
GO


INSERT INTO Enrollments (StudentId, CourseId, EnrollDate, PaymentStatus, PaidAmount)
VALUES
(1, 1, '2026-03-01', 'Paid', 8500),
(2, 1, '2026-03-02', 'Pending', 0),
(2, 2, '2026-03-03', 'Paid', 7500),
(3, 3, '2026-03-04', 'Pending', 0),
(4, 4, '2026-03-05', 'Paid', 6500);
GO

CREATE INDEX IX_Courses_Title ON Courses(Title);
CREATE INDEX IX_Enrollments_StudentId ON Enrollments(StudentId);
CREATE INDEX IX_Enrollments_CourseId ON Enrollments(CourseId);
GO

select * from students;

create database cgclass;
use cgclass;
select * from students;