IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLike]') AND type in (N'U'))
DROP TABLE dbo.UserLike
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.UserLike 
(
	LikeId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,UserId UNIQUEIDENTIFIER NOT NULL
   ,CreatedDate DATETIME NOT NULL
   ,Timestamp timestamp NOT NULL
)

Go



