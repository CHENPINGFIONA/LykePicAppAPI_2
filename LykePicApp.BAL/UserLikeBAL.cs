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
                db.UserLikes.AddOrUpdate(userLike);
                db.SaveChanges();
            }

            return this;
        }

        public UserLikeBAL UnLike(Guid likeId)
        {
            using (var db = new UserLikeContext())
            {
                var userLike = GetUserLike(likeId);
                if (userLike == null)
                {
                    return this;
                }

                db.UserLikes.Remove(userLike);
                db.SaveChanges();
            }

            return this;
        }

        private UserLike GetUserLike(Guid likeId)
        {
            using (var db = new UserLikeContext())
            {
                return db.UserLikes.FirstOrDefault(userLike => userLike.LikeId.Equals(likeId));
            }
        }
    }
}
