using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScoopenAPIBLL;
using ScoopenAPIDAL.Driver;

namespace ScoopenAPI.Controllers
{
    public class DriverController : ApiController
    {
        DriverControllerBLL driverControllerBLL = new DriverControllerBLL(new DriverControllerDAL());

        public HttpResponseMessage DriversList()
        {
            var result = driverControllerBLL.DriversList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
