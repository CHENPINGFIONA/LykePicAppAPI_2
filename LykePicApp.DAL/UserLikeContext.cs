using LykePicApp.Model;
using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class UserLikeContext:DbContext
    {
        public DbSet<UserLike> UserLikes { get; set; }
    }
}
