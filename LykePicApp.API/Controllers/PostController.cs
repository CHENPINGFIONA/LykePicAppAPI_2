using LykePicApp.BAL;
using LykePicApp.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class PostController : BaseController
    {
        [HttpPost]
        public IHttpActionResult Post(UserPost userPost)
        {
            return Run(() =>
            {
                using (var bal = new UserPostBAL())
                {
                    bal.Save(userPost);

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
    }
}
