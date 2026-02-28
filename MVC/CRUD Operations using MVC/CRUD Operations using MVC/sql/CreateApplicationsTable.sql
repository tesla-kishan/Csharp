CREATE TABLE [dbo].[Applications]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ApplicantName] NVARCHAR(200) NOT NULL,
    [Email] NVARCHAR(200) NOT NULL,
    [Phone] NVARCHAR(20) NULL,
    [Position] NVARCHAR(100) NOT NULL,
    [ResumeText] NVARCHAR(MAX) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    [RowVersion] ROWVERSION NOT NULL
);
GO

-- Unique index on Email
CREATE UNIQUE INDEX UX_Applications_Email ON dbo.Applications([Email]);
GO

-- Optional checks
ALTER TABLE dbo.Applications ADD CONSTRAINT CK_Applications_ApplicantName_NotEmpty CHECK (LEN([ApplicantName]) > 1);
GO
