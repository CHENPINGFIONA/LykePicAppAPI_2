using LykePicApp.BAL;
using LykePicApp.Model;
using System;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            using (var bal = new UserBAL())
            {
                bal.Save(user);

                return Ok<string>("Data Successful Saved");
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserInfo(Guid userId)
        {
            using (var bal = new UserBAL())
            {
                var user = bal.GetUser(userId);

                return Ok<User>(user);
            }
        }

        [HttpPost]
        public IHttpActionResult Follow(Guid userId)
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

                return Ok<string>("Data Successful Saved");
            }
        }

        [HttpPost]
        public IHttpActionResult UnFollow(Guid userId)
        {
            using (var bal = new UserFollowerBAL())
            {
                bal.UnFollow(userId);

                return Ok<string>("Data Successful Deleted");
            }
        }        
    }
}
