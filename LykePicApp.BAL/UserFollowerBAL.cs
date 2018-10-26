using LykePicApp.DAL;
using LykePicApp.Model;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserFollowerBAL : BaseBAL
    {
        public UserFollowerBAL Follow(UserFollower userFollower)
        {
            using (var db = new UserFollowerContext())
            {
                var temp = GetUserFollower(userFollower.UserId, userFollower.FollowerUserId);
                if (temp != null)
                {
                    throw new Exception("You have already followed this user.");
                }

                userFollower.CreatedDate = DateTime.Now;
                db.UserFollowers.AddOrUpdate(userFollower);
                db.SaveChanges();
            }

            return this;
        }

        public UserFollowerBAL UnFollow(Guid userId, Guid followerUserId)
        {
            using (var db = new UserFollowerContext())
            {
                var temp = GetUserFollower(userId, followerUserId);
                if (temp == null)
                {
                    throw new Exception("You did not follow this user.");
                }

                db.UserFollowers.Attach(temp);
                db.UserFollowers.Remove(temp);
                db.SaveChanges();
            }

            return this;
        }

        private UserFollower GetUserFollower(Guid userId, Guid followerUserId)
        {
            using (var db = new UserFollowerContext())
            {
                return db.UserFollowers.FirstOrDefault(uf => uf.FollowerUserId.Equals(followerUserId) && uf.UserId.Equals(userId));
            }
        }
    }
}
