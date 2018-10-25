using LykePicApp.Model;
using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class UserContext : BaseContext
    {
        public UserContext() : base() { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
