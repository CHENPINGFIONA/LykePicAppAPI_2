IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_Log]') AND type in (N'U'))
DROP TABLE dbo.Users_Log
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.Users_Log 
(
	LogId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,UserId UNIQUEIDENTIFIER 
   ,UserName NVARCHAR(128) 
   ,Email VARCHAR(128) 
   ,[Password] VARCHAR(512)
   ,ProfilePicture VARCHAR(max)
   ,CreatedDate DATETIME  
   ,LogType VARCHAR(1)
   ,LogDate DATETIME
)

Go



