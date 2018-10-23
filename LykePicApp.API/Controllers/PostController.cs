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
            try
            {
                using (var bal = new UserPostBAL())
                {
                    bal.Save(userPost);

                    return Ok<string>("Data Successful Saved");
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPostList(Guid userId)
        {
            try
            {
                using (var bal = new UserPostBAL())
                {
                    var userPosts = bal.GetUserPosts(userId);

                    return Ok<IList<UserPost>>(userPosts);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
