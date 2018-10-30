IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLogins]') AND type in (N'U'))
DROP TABLE dbo.[UserLogins]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Table dbo.[UserLogins] 
(
	LoginId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() primary key
   ,UserName NVARCHAR(128) NOT NULL
   ,IPv4Address VARCHAR(15) NOT NULL
   ,CreatedDate DATETIME NOT NULL
)

Go



