using LykePicApp.BAL;
using LykePicApp.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    [Authorize]
    public class PostController : BaseController
    {
        [HttpPost]
        public IHttpActionResult Post(UserPost userPost)
        {
            return Run(() =>
            {
                using (var bal = new UserPostBAL())
                {
                    bal.Save(userPost, UserId);

                    return "Data Successful Saved";
                }
            });
        }

        [HttpGet]
        public IHttpActionResult GetPostList(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserPostBAL())
                {
                    return bal.GetUserPosts(userId);
                }
            });
        }

        [HttpGet]
        public IHttpActionResult LikePost(Guid postId)
        {
            return Run(() =>
            {
                using (var bal = new UserLikeBAL())
                {
                    var userLike = new UserLike()
                    {
                        UserId = UserId,
                        PostId = postId,
                        CreatedDate = DateTime.Now
                    };

                    bal.Like(userLike);
                    return "Data Successful Saved";
                }
            });
        }

        [HttpGet]
        public IHttpActionResult UnLike(Guid postId)
        {
            return Run(() =>
            {
                using (var bal = new UserLikeBAL())
                {
                    bal.UnLike(UserId, postId);

                    return "Data Successful Deleted";
                }
            });
        }
    }
}
