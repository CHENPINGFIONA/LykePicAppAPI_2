IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE dbo.[Users]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.[Users] 
(
	UserId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,UserName NVARCHAR(128) NOT NULL
   ,Email VARCHAR(128) NOT NULL
   ,[Password] VARCHAR(512) NOT NULL
   ,ProfilePicture VARCHAR(max)
   ,CreatedDate DATETIME NOT NULL
)

Go



