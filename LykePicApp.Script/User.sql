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
   ,[Name] NVARCHAR(128) NOT NULL
   ,Email VARCHAR(128) NOT NULL
   ,CreatedDate DATETIME NOT NULL
   ,ProfilePicture VARCHAR(max)
   ,Timestamp timestamp NOT NULL
)

Go



