using ScoopenAPIModals.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ScoopenAPIModals.Notifications;
using System.Net;
using RegistrationAndLogin.Service_References;



namespace RegistrationAndLogin.Service_References.Admin
{
    public class AdminRegisterHttpClient: BaseHttpClient, IAdminRegisterHttpClient
    {

        public HttpResponseMessage RegisterAdmin(Admins admins)
        {
            using (ServiceClient)
            {
                try { 
                var resource = string.Format("api/register");

                var response = ServiceClient.PostAsJsonAsync(resource, admins).Result;

                if (response.IsSuccessStatusCode)
                    return response;
                }
                catch(AggregateException e)
                {

                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage ActivateRegisteredAdmin(OtpRequest request)
        {
            using (ServiceClient)
            {
                var resource = string.Format("api/register");

                var response = ServiceClient.PutAsJsonAsync(resource, request).Result;

                if (response.IsSuccessStatusCode)
                    return response;

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Authenticate(AdminLoginRequest login)
        {
            using (ServiceClient)
            {
                var resource = string.Format("api/login");

                var response = ServiceClient.PostAsJsonAsync(resource, login).Result;

                if (response.IsSuccessStatusCode)
                    return response;

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage ChangePasswordOnFirstLogin(AdminLoginRequest login)
        {
            using (ServiceClient)
            {
                var resource = string.Format("api/passwordmanage");

                var response = ServiceClient.PostAsJsonAsync(resource, login).Result;

                if (response.IsSuccessStatusCode)
                    return response;

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

      
    }
}