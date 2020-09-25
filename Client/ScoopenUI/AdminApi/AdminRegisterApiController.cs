//using RegistrationAndLogin.Service_References.Account;
using RegistrationAndLogin.Service_References.Admin;
using ScoopenAPIModals.Admin;
using ScoopenAPIModals.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistrationAndLogin.AdminApi
{
    public class AdminRegisterApiController : ApiController
    {
        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage RegisterAdmin(Admins Admins)
        {
            var registerHttpClient = new AdminRegisterHttpClient();

            var response = registerHttpClient.RegisterAdmin(Admins);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPut]
        [Route("api/register")]
        public HttpResponseMessage ActivateRegisteredAdmin(OtpRequest request)
        {
            var registerHttpClient = new AdminRegisterHttpClient();

            var response = registerHttpClient.ActivateRegisteredAdmin(request);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Authenticate(AdminLoginRequest login)
        {
            var registerHttpClient = new AdminRegisterHttpClient();

            var response = registerHttpClient.Authenticate(login);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPost]
        [Route("api/passwordmanage")]
        public HttpResponseMessage ChangePasswordOnFirstLogin(AdminLoginRequest login)
        {
            var registerHttpClient = new AdminRegisterHttpClient();

            var response = registerHttpClient.ChangePasswordOnFirstLogin(login);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }
    }
}
