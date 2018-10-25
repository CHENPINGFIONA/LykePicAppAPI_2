using LykePicApp.BAL;
using LykePicApp.Model;
using System;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            return Run(() =>
            {
                using (var bal = new UserBAL())
                {
                    bal.Save(user);

                    return "Data Successful Saved";
                }
            });
        }

        [HttpGet]
        public IHttpActionResult GetUserInfo(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserBAL())
                {
                    var user = bal.GetUserById(userId);

                    return user;
                }
            });
        }

        [HttpPost]
        public IHttpActionResult Follow(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserFollowerBAL())
                {
                    var userFollower = new UserFollower()
                    {
                        UserId = Guid.Empty,//todo add here for useridentity.userid
                        FollowerUserId = userId,
                        CreatedDate = DateTime.Now
                    };

                    bal.Follow(userFollower);
                    return "Data Successful Saved";
                }
            });
        }

        [HttpPost]
        public IHttpActionResult UnFollow(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserFollowerBAL())
                {
                    bal.UnFollow(userId);

                    return "Data Successful Deleted";
                }
            });
        }
    }
}
