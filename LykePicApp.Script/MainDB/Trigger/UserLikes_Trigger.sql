IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserLikesLogInsert]'))
DROP Trigger dbo.[UserLikesLogInsert]
GO

CREATE Trigger [dbo].[UserLikesLogInsert] on [dbo].[UserLikes] after insert
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserLikes_Log(LikeId, UserId, PostId,CreatedDate,LogType,LogDate) 
    SELECT inserted.LikeId, 
	inserted.UserId,
	inserted.PostId,
	inserted.CreatedDate,
	'C', 
	getdate() 
    FROM inserted
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserLikesLogUpdate]'))
DROP Trigger dbo.[UserLikesLogUpdate]
GO

Create Trigger [dbo].[UserLikesLogUpdate] on [dbo].[UserLikes] after UPDATE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserLikes_Log(LikeId, UserId, PostId,CreatedDate,LogType,LogDate) 
    SELECT 
	updated.LikeId, 
	updated.UserId,
	updated.PostId,
	updated.CreatedDate,
	'U', 
	getdate() 
    FROM updated
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserLikesLogDelete]'))
DROP Trigger dbo.[UserLikesLogDelete]
GO

Create Trigger [dbo].[UserLikesLogDelete] on [dbo].[UserLikes] after DELETE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserLikes_Log(LikeId, UserId, PostId,CreatedDate,LogType,LogDate) 
    SELECT 
	deleted.LikeId, 
	deleted.UserId,
	deleted.PostId,
	deleted.CreatedDate,
	'D', 
	getdate() 
    FROM deleted
END
GO

