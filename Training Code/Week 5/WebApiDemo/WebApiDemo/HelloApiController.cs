using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiDemo
{
    public class HelloApiController:ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
        public void Post()
        {

        }
    }
}