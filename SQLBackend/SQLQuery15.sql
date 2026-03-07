SELECT TOP (1000) [Id]
      ,[Name]
      ,[M1]
      ,[M2]
  FROM [office].[dbo].[TblStudentMaster]


  INSERT INTO TblStudentMaster (Name, M1, M2)
VALUES ('Arun', 80, 90),
       ('Bala', 70, 85);

SELECT * FROM TblStudentMaster