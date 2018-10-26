using LykePicApp.DAL;
using LykePicApp.Model;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserBAL : BaseBAL
    {
        public void Save(User user)
        {
            using (var db = new UserContext())
            {
                if (user.UserId.Equals(Guid.Empty))
                {
                    user.Password = EncryptHelper.EncryptPassword(user.Password);
                    user.CreatedDate = DateTime.Now;
                }

                db.Users.AddOrUpdate(user);
                db.SaveChanges();
            }
        }

        public User GetUserById(Guid userId)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(user => user.UserId.Equals(userId));
            }
        }

        public User GetUserByName(string userName)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(user => user.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}
