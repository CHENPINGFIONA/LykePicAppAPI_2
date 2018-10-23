using LykePicApp.Model;
using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class UserPostContext : DbContext
    {
        public DbSet<UserPost> UserPosts { get; set; }
    }
}
