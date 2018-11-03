using LykePicApp.BAL;
using LykePicApp.DAL;
using System;
using System.Web.Http;

namespace LykePicApp.API
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
                    user.Password = PasswordHelper.EncryptPassword(user.Password, user.UserName);
                    user.CreatedDate = DateTime.Now;

                    bal.Save(user);

                    return "Data Successful Saved";
                }
            });
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUser(Guid userId)
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
        public IHttpActionResult SearchUsersByText(string text)
        {
            return Run(() =>
            {
                using (var bal = new UserBAL())
                {
                    return bal.SearchUsersByText(text, UserId);
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
                    bal.Follow(UserId, userId);
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

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetFollowerList(Guid userId)
        {
            return Run(() =>
            {
                using (var bal = new UserFollowerBAL())
                {
                    return bal.GetFollowUserList(userId);
                }
            });
        }
    }
}
