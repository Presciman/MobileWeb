using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileWeb.Controllers
{
    public class TestController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage LoginApi()
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.OK);
            return msg;
        }
    }
}
