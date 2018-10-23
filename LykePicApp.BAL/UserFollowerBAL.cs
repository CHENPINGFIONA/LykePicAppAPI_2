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
                db.UserFollowers.AddOrUpdate(userFollower);
                db.SaveChanges();
            }

            return this;
        }

        public UserFollowerBAL UnFollow(Guid followerUserId) {
            using (var db = new UserFollowerContext())
            {
                var userFollower = GetUserFollower(followerUserId);
                if (userFollower == null)
                {
                    return this;
                }

                db.UserFollowers.Remove(userFollower);
                db.SaveChanges();
            }

            return this;
        }

        private UserFollower GetUserFollower(Guid followerUserId)
        {
            using (var db = new UserFollowerContext())
            {
                return db.UserFollowers.FirstOrDefault(userFollower => userFollower.FollowerUserId.Equals(followerUserId));
            }
        }
    }
}
