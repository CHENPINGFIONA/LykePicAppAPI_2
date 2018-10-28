using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserBAL : BaseBAL
    {
        public void Save(User user)
        {
            using (var db = new DBContext())
            {
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
            }
        }

        public User GetUserById(Guid userId)
        {
            using (var db = new DBContext())
            {
                return db.Users.FirstOrDefault(user => user.UserId.Equals(userId));
            }
        }

        public User GetUserByName(string userName)
        {
            using (var db = new DBContext())
            {
                return db.Users.FirstOrDefault(user => user.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public IList<User> SearchUsersByText(string text)
        {
            using (var db = new DBContext())
            {
                return db.Users.Where(u => u.UserName.Contains(text)).ToList();
            }
        }
    }
}
