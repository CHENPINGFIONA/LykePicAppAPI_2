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
                if (user.UserId == Guid.Empty)
                {
                    ValidateUserExist(user.UserName);
                }

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

        public IList<User> SearchUsersByText(string text, Guid userId)
        {
            using (var db = new DBContext())
            {
                var followerUserIds = db.UserFollowers.Where(uf => uf.UserId.Equals(userId)).Select(uf => uf.FollowerUserId);
                return db.Users.Where(u => !followerUserIds.Contains(u.UserId) && !u.UserId.Equals(userId) && u.UserName.Contains(text)).ToList();
            }
        }

        private void ValidateUserExist(string userName)
        {
            var temp = GetUserByName(userName);
            if (temp != null)
            {
                throw new Exception("User Name already exist in the system.");
            }
        }
    }
}
