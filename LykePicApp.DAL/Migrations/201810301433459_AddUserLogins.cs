namespace LykePicApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUserLogins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.UserLogins",
               c => new
               {
                   LoginId = c.Guid(nullable: false, identity: true),
                   UserName = c.String(),
                   IPV4Address = c.String(),
                   IsSuccessful = c.Boolean(),
                   CreatedDate = c.DateTime(nullable: false),
               })
               .PrimaryKey(t => t.LoginId);
        }

        public override void Down()
        {
            DropTable("dbo.UserLogins");
        }
    }
}
