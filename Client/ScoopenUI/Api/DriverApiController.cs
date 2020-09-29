using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RegistrationAndLogin.Service_References.Driver;

namespace RegistrationAndLogin.Api
{
    public class DriverApiController : ApiController
    {
        DriverHttpClient driverHttpClient = new DriverHttpClient();

        public HttpResponseMessage DriversList()
        {
           var response= driverHttpClient.DriversList();

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }
    }
}
