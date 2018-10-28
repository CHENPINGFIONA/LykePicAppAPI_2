using LykePicApp.BAL;
using LykePicApp.DAL;
using System;
using System.Web.Http;

namespace LykePicApp.API
{
    [Authorize]
    public class PostController : BaseController
    {
        [HttpPost]
        public IHttpActionResult UploadPost(UserPost post)
        {
            return Run(() =>
            {
                using (var bal = new UserPostBAL())
                {
                    post.UserId = UserId;
                    post.CreatedDate = DateTime.Now;
                    bal.Save(post);

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
        public IHttpActionResult GetPost(Guid postId)
        {
            return Run(() =>
            {
                using (var bal = new UserPostBAL())
                {
                    return bal.GetUserPost(postId);
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
                    bal.Like(UserId, postId);

                    return "Data Successful Saved";
                }
            });
        }

        [HttpGet]
        public IHttpActionResult DisLikePost(Guid postId)
        {
            return Run(() =>
            {
                using (var bal = new UserLikeBAL())
                {
                    bal.DisLike(UserId, postId);

                    return "Data Successful Deleted";
                }
            });
        }
    }
}
