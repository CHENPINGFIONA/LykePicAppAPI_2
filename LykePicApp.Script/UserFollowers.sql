IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFollowers]') AND type in (N'U'))
DROP TABLE dbo.[UserFollowers]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.[UserFollowers] 
(
	UserId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,FollowerUserId UNIQUEIDENTIFIER NOT NULL
   ,CreatedDate DATETIME NOT NULL
   ,Timestamp timestamp NOT NULL
)

Go



