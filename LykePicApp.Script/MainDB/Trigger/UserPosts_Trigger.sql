IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserPostsLogInsert]'))
DROP Trigger dbo.[UserPostsLogInsert]
GO

CREATE Trigger [dbo].[UserPostsLogInsert] on [dbo].[UserPosts] after insert
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserPosts_Log(PostId, UserId, Picture,[Description],CreatedDate,LogType,LogDate) 
    SELECT inserted.PostId, 
	inserted.UserId,
	inserted.Picture,
	inserted.[Description],
	inserted.CreatedDate,
	'C', 
	getdate() 
    FROM inserted
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserPostsLogUpdate]'))
DROP Trigger dbo.[UserPostsLogUpdate]
GO

Create Trigger [dbo].[UserPostsLogUpdate] on [dbo].[UserPosts] after UPDATE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserPosts_Log(PostId, UserId, Picture,[Description],CreatedDate,LogType,LogDate) 
     SELECT 
	updated.PostId, 
	updated.UserId,
	updated.Picture,
	updated.[Description],
	updated.CreatedDate,
	'U', 
	getdate() 
    FROM updated
END
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[UserPostsLogDelete]'))
DROP Trigger dbo.[UserPostsLogDelete]
GO

Create Trigger [dbo].[UserPostsLogDelete] on [dbo].[UserPosts] after DELETE
AS 
Begin
  Set nocount on

  Insert into LykePicAppConn_Log.dbo.UserPosts_Log(PostId, UserId, Picture,[Description],CreatedDate,LogType,LogDate) 
    SELECT 
	deleted.PostId, 
	deleted.UserId,
	deleted.Picture,
	deleted.[Description],
	deleted.CreatedDate,
	'D', 
	getdate() 
    FROM deleted
END
GO

