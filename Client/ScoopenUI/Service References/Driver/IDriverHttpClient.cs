using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RegistrationAndLogin.Service_References.Driver
{
    public interface IDriverHttpClient
    {
        HttpResponseMessage DriversList();

    }
}