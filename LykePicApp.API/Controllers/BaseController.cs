using LykePicApp.Auth;
using System;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class BaseController : ApiController
    {
        protected Guid UserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }

        protected IHttpActionResult Run(Func<object> resolve)
        {
            try
            {
                return Ok(resolve());
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
