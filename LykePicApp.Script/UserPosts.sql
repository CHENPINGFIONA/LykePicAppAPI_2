IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserPosts]') AND type in (N'U'))
DROP TABLE dbo.UserPosts
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.UserPosts
(
	PostId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,UserId UNIQUEIDENTIFIER NOT NULL
   ,Picture VARCHAR(max) 
   ,CreatedDate DATETIME NOT NULL
   ,Timestamp timestamp NOT NULL
)

Go



