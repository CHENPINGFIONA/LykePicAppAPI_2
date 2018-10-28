namespace LykePicApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPostAddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPosts", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPosts", "Description");
        }
    }
}
