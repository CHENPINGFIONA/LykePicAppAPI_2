IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLikes_Log]') AND type in (N'U'))
DROP TABLE dbo.UserLikes_Log
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.UserLikes_Log 
(
	LogId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,LikeId UNIQUEIDENTIFIER  
   ,UserId UNIQUEIDENTIFIER 
   ,PostId UNIQUEIDENTIFIER 
   ,CreatedDate DATETIME 
   ,LogType VARCHAR(1)
   ,LogDate DATETIME
)

Go


