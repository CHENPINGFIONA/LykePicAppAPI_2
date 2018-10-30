IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserFollowersLogInsert]'))
DROP Trigger dbo.UserFollowersLogInsert
GO

CREATE Trigger [dbo].UserFollowersLogInsert on [dbo].[UserFollowers] after insert
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserFollowers_Log(UserId, FollowerUserId,CreatedDate,LogType,LogDate) 
    SELECT inserted.UserId, 
	inserted.FollowerUserId,
	inserted.CreatedDate,
	'C', 
	getdate() 
    FROM inserted
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserFollowersLogUpdate]'))
DROP Trigger dbo.[UserFollowersLogUpdate]
GO

Create Trigger [dbo].[UserFollowersLogUpdate] on [dbo].[UserFollowers] after UPDATE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserFollowers_Log(UserId, FollowerUserId,CreatedDate,LogType,LogDate) 
    SELECT 
	updated.UserId, 
	updated.FollowerUserId,
	updated.CreatedDate,
	'U', 
	getdate() 
    FROM updated
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserFollowersLogDelete]'))
DROP Trigger dbo.[UserFollowersLogDelete]
GO

Create Trigger [dbo].[UserFollowersLogDelete] on [dbo].[UserFollowers] after DELETE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserFollowers_Log(UserId, FollowerUserId,CreatedDate,LogType,LogDate) 
    SELECT 
	deleted.UserId, 
	deleted.FollowerUserId,
	deleted.CreatedDate,
	'D', 
	getdate() 
    FROM deleted
END
GO

