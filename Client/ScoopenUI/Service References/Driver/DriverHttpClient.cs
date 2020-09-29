using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace RegistrationAndLogin.Service_References.Driver
{
    public class DriverHttpClient : BaseHttpClient, IDriverHttpClient
    {
        public HttpResponseMessage DriversList()
        {
            using (ServiceClient)
            {
                var resource = string.Format("api/driver");

                var response = ServiceClient.GetAsync(resource).Result;

                if (response.IsSuccessStatusCode)
                    return response;

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}