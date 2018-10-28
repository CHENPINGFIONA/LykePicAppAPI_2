using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace LykePicApp.BAL
{
    public class UserPostBAL : BaseBAL
    {
        public void Save(UserPost post)
        {
            using (var db = new DBContext())
            {
                db.UserPosts.AddOrUpdate(post);
                db.SaveChanges();
            }
        }

        public void Delete(Guid postId)
        {
            using (var db = new DBContext())
            {
                var post = GetUserPost(postId);
                if (post == null)
                {
                    return;
                }

                db.UserPosts.Remove(post);
                db.SaveChanges();
            }
        }

        public IList<UserPost> GetUserPosts(Guid userId)
        {
            using (var db = new DBContext())
            {
                var followerList = db.UserFollowers.Where(uf => uf.UserId.Equals(userId));

                var query = from post in db.UserPosts
                            join follower in followerList on post.UserId equals follower.FollowerUserId into temp
                            from p in temp.DefaultIfEmpty()
                            where p.UserId == userId
                            || p.FollowerUserId == userId
                            orderby post.CreatedDate descending
                            select post;

                return query.ToList();
            }
        }

        public UserPost GetUserPost(Guid postId)
        {
            using (var db = new DBContext())
            {
                return db.UserPosts.FirstOrDefault(post => post.PostId.Equals(postId));
            }
        }
    }
}
