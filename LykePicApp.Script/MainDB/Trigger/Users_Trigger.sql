IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UsersLogInsert]'))
DROP Trigger dbo.[UsersLogInsert]
GO

CREATE Trigger [dbo].[UsersLogInsert] on [dbo].[Users] after insert
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.Users_Log(UserId, UserName, Email,[Password],ProfilePicture,CreatedDate,LogType,LogDate) 
    SELECT inserted.UserId, 
	inserted.UserName,
	inserted.Email,
	inserted.[Password],
	inserted.ProfilePicture,
	inserted.CreatedDate,
	'C', 
	getdate() 
    FROM inserted
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UsersLogUpdate]'))
DROP Trigger dbo.[UsersLogUpdate]
GO

Create Trigger [dbo].[UsersLogUpdate] on [dbo].[Users] after UPDATE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.Users_Log(UserId, UserName, Email,[Password],ProfilePicture,CreatedDate,LogType,LogDate) 
    SELECT 
	updated.UserId, 
	updated.UserName,
	updated.Email,
	updated.[Password],
	updated.ProfilePicture,
	updated.CreatedDate,
	'U', 
	getdate() 
    FROM updated
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UsersLogDelete]'))
DROP Trigger dbo.[UsersLogDelete]
GO

Create Trigger [dbo].[UsersLogDelete] on [dbo].[Users] after DELETE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.Users_Log(UserId, UserName, Email,[Password],ProfilePicture,CreatedDate,LogType,LogDate) 
    SELECT 
	deleted.UserId, 
	deleted.UserName,
	deleted.Email,
	deleted.[Password],
	deleted.ProfilePicture,
	deleted.CreatedDate,
	'D', 
	getdate() 
    FROM deleted
END
GO

