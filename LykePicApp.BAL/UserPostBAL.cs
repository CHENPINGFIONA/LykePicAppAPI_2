using LykePicApp.DAL;
using LykePicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace LykePicApp.BAL
{
    public class UserPostBAL : BaseBAL
    {
        public void Save(UserPost userPost, Guid userId)
        {
            using (var db = new UserPostContext())
            {
                if (userPost.PostId.Equals(Guid.Empty))
                {
                    userPost.UserId = userId;
                    userPost.CreatedDate = DateTime.Now;
                }

                db.UserPosts.AddOrUpdate(userPost);
                db.SaveChanges();
            }
        }

        public void Delete(Guid postId)
        {
            using (var db = new UserPostContext())
            {
                var userPost = GetUserPost(postId);
                if (userPost == null)
                {
                    return;
                }

                db.UserPosts.Remove(userPost);
                db.SaveChanges();
            }
        }

        public IList<UserPost> GetUserPosts(Guid userId)
        {
            using (var db = new UserPostContext())
            {
                var query = from post in db.UserPosts
                            orderby post.CreatedDate descending
                            select post;

                return query.ToList();
            }
        }

        private UserPost GetUserPost(Guid postId)
        {
            using (var db = new UserPostContext())
            {
                return db.UserPosts.FirstOrDefault(userPost => userPost.PostId.Equals(postId));
            }
        }
    }
}
