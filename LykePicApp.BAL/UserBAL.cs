using LykePicApp.DAL;
using LykePicApp.Model;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserBAL : BaseBAL
    {
        public UserBAL Save(User user)
        {
            using (var db = new UserContext())
            {
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
            }

            return this;
        }

        public User GetUser(Guid userId)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(user => user.UserId.Equals(userId));
            }
        }
    }
}
