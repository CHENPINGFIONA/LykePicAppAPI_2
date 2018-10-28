using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserFollowerBAL : BaseBAL
    {
        public void Follow(Guid userId, Guid followerUserId)
        {
            using (var db = new DBContext())
            {
                AddUser(db.UserFollowers, userId, followerUserId);
                AddUser(db.UserFollowers, followerUserId, userId);

                db.SaveChanges();
            }
        }

        public void UnFollow(Guid userId, Guid followerUserId)
        {
            using (var db = new DBContext())
            {
                RemoveUser(db.UserFollowers, userId, followerUserId);
                RemoveUser(db.UserFollowers, followerUserId, userId);

                db.SaveChanges();
            }
        }

        public IList<User> GetFollowUserList(Guid userId)
        {
            using (var db = new DBContext())
            {
                var followerList = db.UserFollowers.Where(uf => uf.UserId.Equals(userId));

                return (from user in db.Users
                        join follower in followerList on user.UserId equals follower.FollowerUserId
                        orderby user.UserName
                        select user).ToList();
            }
        }

        private UserFollower GetUserFollower(Guid userId, Guid followerUserId)
        {
            using (var db = new DBContext())
            {
                return db.UserFollowers.FirstOrDefault(uf => uf.FollowerUserId.Equals(followerUserId) && uf.UserId.Equals(userId));
            }
        }

        private void AddUser(DbSet<UserFollower> followerDbSet, Guid userId, Guid followerUserId)
        {
            var temp = GetUserFollower(userId, followerUserId);
            if (temp != null)
            {
                throw new Exception("You have already followed this user.");
            }

            temp = new UserFollower()
            {
                UserId = userId,
                FollowerUserId = followerUserId,
                CreatedDate = DateTime.Now
            };

            followerDbSet.AddOrUpdate(temp);
        }

        private void RemoveUser(DbSet<UserFollower> followerDbSet, Guid userId, Guid followerUserId)
        {
            var tempUser = GetUserFollower(userId, followerUserId);
            if (tempUser == null)
            {
                throw new Exception("You did not follow this user.");
            }

            followerDbSet.Attach(tempUser);
            followerDbSet.Remove(tempUser);
        }
    }
}
