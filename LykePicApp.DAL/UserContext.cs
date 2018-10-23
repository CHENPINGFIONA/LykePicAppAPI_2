using LykePicApp.Model;
using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
