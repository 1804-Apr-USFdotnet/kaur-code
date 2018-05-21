using AuthTest2Consumer.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthTest2Consumer.Controllers
{
    public class AccountController : AServiceController
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<ActionResult> Login(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var request = CreateRequestToService(HttpMethod.Post, "api/Account/Login");
            request.Content = new ObjectContent<Account>(account, new JsonMediaTypeFormatter());
            var response = await HttpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(response);

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Logout
        public async Task<ActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var request = CreateRequestToService(HttpMethod.Get, "api/Account/Logout");
            var response = await HttpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(response);

            return RedirectToAction("Index", "Home");
        }

        private bool PassCookiesToClient(HttpResponseMessage response)
        {
            if (response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                foreach (var value in values)
                {
                    Response.Headers.Add("Set-Cookie", value);
                }
                return true;
            }
            return false;
        }
    }
}