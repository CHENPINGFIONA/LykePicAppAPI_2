using LykePicApp.Model;
using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class UserFollowerContext:DbContext
    {
        public DbSet<UserFollower> UserFollowers { get; set; }
    }
}
