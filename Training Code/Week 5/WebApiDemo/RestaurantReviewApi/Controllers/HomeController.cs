using System.Web.Mvc;

namespace RestaurantReviewApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Restaurant Page";

            return View();
        }
    }
}
