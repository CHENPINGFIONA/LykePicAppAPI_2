using LykePicApp.DAL;
using LykePicApp.Model;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserLikeBAL : BaseBAL
    {
        public UserLikeBAL Like(UserLike userLike)
        {
            using (var db = new UserLikeContext())
            {
                var temp = GetUserLike(userLike.UserId, userLike.PostId);
                if (temp != null)
                {
                    throw new Exception("You have already liked this post.");
                }

                db.UserLikes.AddOrUpdate(userLike);
                db.SaveChanges();
            }

            return this;
        }

        public UserLikeBAL UnLike(Guid userId, Guid postId)
        {
            using (var db = new UserLikeContext())
            {
                var temp = GetUserLike(userId, postId);
                if (temp == null)
                {
                    throw new Exception("You did not like this post.");
                }

                db.UserLikes.Attach(temp);
                db.UserLikes.Remove(temp);
                db.SaveChanges();
            }

            return this;
        }

        private UserLike GetUserLike(Guid userId, Guid postId)
        {
            using (var db = new UserLikeContext())
            {
                return db.UserLikes.FirstOrDefault(ul => ul.PostId.Equals(postId) && ul.UserId.Equals(userId));
            }
        }
    }
}
