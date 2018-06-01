using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerizedMvc2.Models;
using System.Net.Http;

namespace DockerizedMvc2.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<IActionResult> IndexAsync()
        {
            var response = await httpClient.GetAsync("http://api:4200/api/value/1");
            var contentString = await response.Content.ReadAsStringAsync();

            ViewBag.Message = contentString;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
