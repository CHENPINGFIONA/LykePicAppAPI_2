using System;
using System.Web.Http;
using System.Web.Mvc;

namespace LykePicApp.API.Controllers
{
    public class BaseController : ApiController
    {
        //TODO AUTHENTICATION

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
