using LykePicApp.Model;
using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class UserFollowerContext : BaseContext
    {
        public UserFollowerContext() : base() { }

        public DbSet<UserFollower> UserFollowers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
