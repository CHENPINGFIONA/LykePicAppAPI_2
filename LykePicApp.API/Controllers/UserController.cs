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

        [HttpGet]
        public IHttpActionResult GetPublicKey() {
            return Ok(@"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCeQAqPrGgrjcXo1YPlh5fMBFv4
9MXUc4GQc6lcbRdIqPUsui7UvkrQh/exlQTK/5NZCmXhXotF4idFCnmzWXt5Ynmq
soO/5jXLCf6PuB/xY3gusWfdrQe50aJ2oL5bYUv3DzaalVrxyNEBM9eCwXOfsCKT
K22qUQHSXKPr8WAGLwIDAQAB");
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

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUserInfo(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserBAL())
                {
                    return bal.GetUserById(userId);
                }
            });
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult Follow(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserFollowerBAL())
                {
                    var userFollower = new UserFollower()
                    {
                        UserId = UserId,
                        FollowerUserId = userId,
                        CreatedDate = DateTime.Now
                    };

                    bal.Follow(userFollower);
                    return "Data Successful Saved";
                }
            });
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult UnFollow(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserFollowerBAL())
                {
                    bal.UnFollow(UserId, userId);

                    return "Data Successful Deleted";
                }
            });
        }
    }
}
