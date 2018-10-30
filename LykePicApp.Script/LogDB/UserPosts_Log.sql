IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserPosts_Log]') AND type in (N'U'))
DROP TABLE dbo.UserPosts_Log
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.UserPosts_Log
(
    LogId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,PostId UNIQUEIDENTIFIER 
   ,UserId UNIQUEIDENTIFIER 
   ,Picture VARCHAR(max) 
   ,Description NVARCHAR(2048)
   ,CreatedDate DATETIME
   ,LogType VARCHAR(1)
   ,LogDate DATETIME
)

Go



