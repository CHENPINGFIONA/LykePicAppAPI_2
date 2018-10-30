IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFollowers_Log]') AND type in (N'U'))
DROP TABLE dbo.[UserFollowers_Log]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.[UserFollowers_Log] 
(
   LogId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,UserId UNIQUEIDENTIFIER  
   ,FollowerUserId UNIQUEIDENTIFIER  
   ,CreatedDate DATETIME
   ,LogType VARCHAR(1)
   ,LogDate DATETIME
)

Go



