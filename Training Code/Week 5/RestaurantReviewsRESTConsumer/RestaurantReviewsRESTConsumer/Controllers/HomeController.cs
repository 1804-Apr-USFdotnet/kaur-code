using Newtonsoft.Json;
using RestaurantReviewsRESTConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RestaurantReviewsRESTConsumer.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> List()
        {
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:62952/api/Restaurants/");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var restaurants = await response.Content.ReadAsAsync<IEnumerable<Restaurant>>();
            //var contentString = await response.Content.ReadAsStringAsync();
            //var restaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(contentString);

            return View(restaurants);
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