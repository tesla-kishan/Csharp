use capgemini;

CREATE TABLE Hostels
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100),
    Age INT,
    City VARCHAR(100)
)


INSERT INTO Hostels (Name, Age, City)
VALUES
('Student1',20,'Delhi'),
('Student2',21,'Mumbai'),
('Student3',22,'Pune'),
('Student4',23,'Delhi'),
('Student5',20,'Noida'),
('Student6',21,'Delhi'),
('Student7',22,'Mumbai'),
('Student8',23,'Pune'),
('Student9',20,'Delhi'),
('Student10',21,'Noida'),

('Student11',22,'Delhi'),
('Student12',23,'Mumbai'),
('Student13',20,'Pune'),
('Student14',21,'Delhi'),
('Student15',22,'Noida'),
('Student16',23,'Delhi'),
('Student17',20,'Mumbai'),
('Student18',21,'Pune'),
('Student19',22,'Delhi'),
('Student20',23,'Noida'),

('Student21',20,'Delhi'),
('Student22',21,'Mumbai'),
('Student23',22,'Pune'),
('Student24',23,'Delhi'),
('Student25',20,'Noida'),
('Student26',21,'Delhi'),
('Student27',22,'Mumbai'),
('Student28',23,'Pune'),
('Student29',20,'Delhi'),
('Student30',21,'Noida'),

('Student31',22,'Delhi'),
('Student32',23,'Mumbai'),
('Student33',20,'Pune'),
('Student34',21,'Delhi'),
('Student35',22,'Noida'),
('Student36',23,'Delhi'),
('Student37',20,'Mumbai'),
('Student38',21,'Pune'),
('Student39',22,'Delhi'),
('Student40',23,'Noida'),

('Student41',20,'Delhi'),
('Student42',21,'Mumbai'),
('Student43',22,'Pune'),
('Student44',23,'Delhi'),
('Student45',20,'Noida'),
('Student46',21,'Delhi'),
('Student47',22,'Mumbai'),
('Student48',23,'Pune'),
('Student49',20,'Delhi'),
('Student50',21,'Noida'),

('Student51',22,'Delhi'),
('Student52',23,'Mumbai'),
('Student53',20,'Pune'),
('Student54',21,'Delhi'),
('Student55',22,'Noida'),
('Student56',23,'Delhi'),
('Student57',20,'Mumbai'),
('Student58',21,'Pune'),
('Student59',22,'Delhi'),
('Student60',23,'Noida'),

('Student61',20,'Delhi'),
('Student62',21,'Mumbai'),
('Student63',22,'Pune'),
('Student64',23,'Delhi'),
('Student65',20,'Noida'),
('Student66',21,'Delhi'),
('Student67',22,'Mumbai'),
('Student68',23,'Pune'),
('Student69',20,'Delhi'),
('Student70',21,'Noida'),

('Student71',22,'Delhi'),
('Student72',23,'Mumbai'),
('Student73',20,'Pune'),
('Student74',21,'Delhi'),
('Student75',22,'Noida'),
('Student76',23,'Delhi'),
('Student77',20,'Mumbai'),
('Student78',21,'Pune'),
('Student79',22,'Delhi'),
('Student80',23,'Noida'),

('Student81',20,'Delhi'),
('Student82',21,'Mumbai'),
('Student83',22,'Pune'),
('Student84',23,'Delhi'),
('Student85',20,'Noida'),
('Student86',21,'Delhi'),
('Student87',22,'Mumbai'),
('Student88',23,'Pune'),
('Student89',20,'Delhi'),
('Student90',21,'Noida'),

('Student91',22,'Delhi'),
('Student92',23,'Mumbai'),
('Student93',20,'Pune'),
('Student94',21,'Delhi'),
('Student95',22,'Noida'),
('Student96',23,'Delhi'),
('Student97',20,'Mumbai'),
('Student98',21,'Pune'),
('Student99',22,'Delhi'),
('Student100',23,'Noida');


SELECT * FROM Hostels


CREATE PROCEDURE GetStudentsPaged
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SELECT *
    FROM hostels
    ORDER BY Id
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY
END

ALTER PROCEDURE GetStudentsPaged
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SELECT *
    FROM Hostels
    ORDER BY Id
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY
END

EXEC GetStudentsPaged 10,10
