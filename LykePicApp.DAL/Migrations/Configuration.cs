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
                Password = "$argon2i$v=19$m=32768,t=10,p=5$dDNwdDEyMzQ1Njc4$pcUgrx3qZbdgnSs7T1y0hN/AB1E=",
                CreatedDate = DateTime.Now
            });

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
