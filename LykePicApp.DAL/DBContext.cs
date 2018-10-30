using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class DBContext : DbContext
    {
        public DBContext() : base("LykePicAppConn") { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserFollower> UserFollowers { get; set; }

        public DbSet<UserPost> UserPosts { get; set; }

        public DbSet<UserLike> UserLikes { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }
    }
}
