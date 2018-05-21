using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthTest2Consumer.Controllers
{
    public class HomeController : AServiceController
    {
        public async Task<ActionResult> Index()
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/Data");

            var response = await HttpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode != HttpStatusCode.Unauthorized)
                {
                    return View("Error");
                }
                ViewBag.Message = "Not logged in!";
            }
            else
            {
                var contentString = await response.Content.ReadAsStringAsync();
                ViewBag.Message = "Logged in! Result: " + contentString;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}