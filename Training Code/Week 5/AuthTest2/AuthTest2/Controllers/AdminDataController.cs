using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthTest2.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminDataController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("You're an Admin!");
        }
    }
}
