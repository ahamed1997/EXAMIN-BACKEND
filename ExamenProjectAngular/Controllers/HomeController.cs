using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenBL;
using ExamenUserLibrary;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace ExamenProjectAngular.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,PUT,POST")]
    public class HomeController : Controller
    {
        ProjectBL bl = new ProjectBL();
        UserLibrary user = new UserLibrary();
        static List<UserLibrary> users = new List<UserLibrary>();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public bool Post([FromBody]UserLibrary value)
        {
            if (User != null)
            {
                return bl.AdminLogInUserValidation(value);

            }
            else
                return false;
        }

    }
}
