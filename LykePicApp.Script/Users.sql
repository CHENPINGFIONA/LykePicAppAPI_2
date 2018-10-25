IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE dbo.[User]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.[User] 
(
	UserId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,UserName NVARCHAR(128) NOT NULL
   ,Email VARCHAR(128) NOT NULL
   ,PasswordHash VARCHAR(512) NOT NULL
   ,ProfilePicture VARCHAR(max)
   ,CreatedDate DATETIME NOT NULL
   ,Timestamp timestamp NOT NULL
)

Go



