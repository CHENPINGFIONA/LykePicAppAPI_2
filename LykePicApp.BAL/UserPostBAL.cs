using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Data.Entity;

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

        public IList<UserPostBM> GetUserPosts(Guid userId)
        {
            var userPosts = new List<UserPostBM>();
            using (var db = new DBContext())
            {
                var likes = db.UserLikes.ToList();
                var followerList = db.UserFollowers.Where(uf => uf.UserId.Equals(userId));
                var followerPostList = from post in db.UserPosts
                                       join follower in followerList on post.UserId equals follower.FollowerUserId
                                       select post;
                userPosts.AddRange(GetUserPost(followerPostList, likes));

                var userPostList = db.UserPosts.Where(post => post.UserId == userId);
                userPosts.AddRange(GetUserPost(userPostList, likes));

                return userPosts;
            }
        }

        public UserPostBM GetUserPost(Guid postId)
        {
            using (var db = new DBContext())
            {
                var post = db.UserPosts.FirstOrDefault(p => p.PostId.Equals(postId));
                var postBM = UserPostBM.From(post);

                postBM.LikeCount = db.UserLikes.Count(ul => ul.PostId.Equals(post.PostId));

                return postBM;
            }
        }

        private IList<UserPostBM> GetUserPost(IEnumerable<UserPost> posts, IEnumerable<UserLike> likes)
        {
            var userPosts = new List<UserPostBM>();
            foreach (var post in posts)
            {
                var postBM = UserPostBM.From(post);
                postBM.LikeCount = likes.Count(like => like.PostId.Equals(post.PostId));
                userPosts.Add(postBM);
            }

            return userPosts;
        }
    }

    public sealed class UserPostBM : UserPost
    {
        public int LikeCount { get; set; }

        public static UserPostBM From(UserPost post)
        {
            return new UserPostBM()
            {
                PostId = post.PostId,
                UserId = post.UserId,
                Picture = post.Picture,
                Description = post.Description,
                CreatedDate = post.CreatedDate
            };

        }
    }

}
