using LykePicApp.DAL;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserLikeBAL : BaseBAL
    {
        public void Like(Guid userId, Guid postId)
        {
            using (var db = new DBContext())
            {
                var temp = GetUserLike(userId, postId);
                if (temp != null)
                {
                    throw new Exception("You have already liked this post.");
                }

                temp = new UserLike()
                {
                    UserId = userId,
                    PostId = postId,
                    CreatedDate = DateTime.Now
                };

                db.UserLikes.AddOrUpdate(temp);
                db.SaveChanges();
            }
        }

        public void DisLike(Guid userId, Guid postId)
        {
            using (var db = new DBContext())
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
        }

        private UserLike GetUserLike(Guid userId, Guid postId)
        {
            using (var db = new DBContext())
            {
                return db.UserLikes.FirstOrDefault(ul => ul.PostId.Equals(postId) && ul.UserId.Equals(userId));
            }
        }
    }
}
