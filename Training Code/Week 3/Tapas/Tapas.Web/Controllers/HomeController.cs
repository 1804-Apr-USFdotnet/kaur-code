using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tapas.Web.Controllers
{
    public class HomeController : Controller
    {
        
        
        //Action Methods
        // GET: Home
        
        public string Hello()
        {
            return "Hello world";
        }
        public string Welcome()
        {
            return "Welcome to <b> USF-Revature</b>";
        }
        [NonAction]
        public ContentResult Test()
        {
            return Content(HttpUtility.HtmlEncode("This is the .Net <script>alert('Your System is Hacked')</script> Training program"));
        }
        [Authorize]
        
        [HandleError]
        public ActionResult Index()
        {
            TempData["Training"] = ".Net Full Stack";
            return View("ContactUs");
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult TestIndex()
        {
            TempData.Keep("Training");
            return View();
        }
       
    }
}