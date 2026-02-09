create database scriptt;
use scriptt;

CREATE TABLE ContactDetails
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    Email VARCHAR(50),
    FatherPhone VARCHAR(15),
    MotherPhone VARCHAR(15),
    Landline VARCHAR(15),
    FriendPhone VARCHAR(15)
);


INSERT INTO ContactDetails (Name, Email, FatherPhone, MotherPhone, Landline, FriendPhone)
VALUES
('Manimuthu', NULL, '9876543210', NULL, NULL, NULL),
('Ravi', 'ravi@gmail.com', NULL, NULL, '0441234567', NULL),
('Anita', NULL, NULL, NULL, NULL, NULL);

--update ContactDetails
--set Name='marimuthu'
--WHERE Name = 'Manimuthu';

SELECT ISNULL(Email, 'No Email Id exists') AS Email
FROM ContactDetails;

SELECT ISNULL(FatherPhone, 'No Father Phone number exists') AS FatherPhone
FROM ContactDetails;

SELECT ISNULL(MotherPhone, 'No Mother Phone number exists') AS MotherPhone
FROM ContactDetails;

SELECT ISNULL(Landline, 'No Landline number exists') AS Landline
FROM ContactDetails;

SELECT ISNULL(Email, 'No Email Id exists') AS Email
FROM ContactDetails;

SELECT ISNULL(FatherPhone, 'No Father Phone number exists') AS FatherPhone
FROM ContactDetails;

SELECT ISNULL(MotherPhone, 'No Mother Phone number exists') AS MotherPhone
FROM ContactDetails;

SELECT ISNULL(Landline, 'No Landline number exists') AS Landline
FROM ContactDetails;

SELECT 
    Name,
    COALESCE(
        Email,
        FatherPhone,
        MotherPhone,
        Landline,
        FriendPhone,
        'No contact details'
    ) AS ContactInfo
FROM ContactDetails;

--
--	•	COALESCE() checks columns from left to right
--	•	Returns the first NOT NULL value
--	•	If all columns are NULL, it returns:

