namespace LykePicApp.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LykePicApp.DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LykePicApp.DAL.DBContext context)
        {
            context.Users.Add(new User()
            {
                UserName = "t3pt",
                Email = "t3pt@mail.com",
                Password = "92efa8383265cd69e766caa990d37d1d5870a8477583ba44a35f30c42f133bc2",
                CreatedDate = DateTime.Now
            });

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
