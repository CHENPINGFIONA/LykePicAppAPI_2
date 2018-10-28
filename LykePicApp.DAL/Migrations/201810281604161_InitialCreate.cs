namespace LykePicApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFollowers",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        FollowerUserId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowerUserId });
            
            CreateTable(
                "dbo.UserLikes",
                c => new
                    {
                        LikeId = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LikeId);
            
            CreateTable(
                "dbo.UserPosts",
                c => new
                    {
                        PostId = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Picture = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ProfilePicture = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserPosts");
            DropTable("dbo.UserLikes");
            DropTable("dbo.UserFollowers");
        }
    }
}
