using LykePicApp.BAL;
using System;
using System.Web.Mvc;

namespace LykePicApp.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var DAL = new UserBAL())
            {
                var user = DAL.GetUserByName("t3pt");
                Console.WriteLine(user.UserName);
            }

            return View();
        }
    }
}
