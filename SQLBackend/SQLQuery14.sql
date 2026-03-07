SELECT TOP (1000) [Id]
      ,[Name]
      ,[Author]
      ,[Price]
  FROM [capgemini].[dbo].[Books]


  INSERT INTO Books VALUES ('Java','James',600)
INSERT INTO Books VALUES ('Python','Guido',450)
INSERT INTO Books VALUES ('C#','Microsoft',700)

INSERT INTO Books (Name, Author, Price) VALUES ('Java', 'James Gosling', 650);
INSERT INTO Books (Name, Author, Price) VALUES ('Python', 'Guido Van Rossum', 500);
INSERT INTO Books (Name, Author, Price) VALUES ('C++', 'Bjarne Stroustrup', 750);
INSERT INTO Books (Name, Author, Price) VALUES ('JavaScript', 'Brendan Eich', 550);
INSERT INTO Books (Name, Author, Price) VALUES ('C#', 'Microsoft', 700);
INSERT INTO Books (Name, Author, Price) VALUES ('Spring Boot', 'Rod Johnson', 800);
INSERT INTO Books (Name, Author, Price) VALUES ('React', 'Jordan Walke', 600);
INSERT INTO Books (Name, Author, Price) VALUES ('Angular', 'Google', 650);

INSERT INTO Books (FullName, Author, Price) VALUES ('HTML Basics', 'Tim Berners-Lee', 150);
INSERT INTO Books (FullName, Author, Price) VALUES ('CSS Guide', 'W3C', 250);
INSERT INTO Books (FullName, Author, Price) VALUES ('Java Fundamentals', 'Oracle', 350);
INSERT INTO Books (FullName, Author, Price) VALUES ('NodeJS Intro', 'Ryan Dahl', 399);
INSERT INTO Books (FullName, Author, Price) VALUES ('Bootstrap', 'Mark Otto', 200);


select * from books;