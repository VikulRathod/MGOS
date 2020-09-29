﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using RegistrationAndLogin.Service_References.Account;
using ScoopenModals.Account;
using ScoopenAPIModals.Notifications;

namespace RegistrationAndLogin.Api
{
    public class RegisterApiController : System.Web.Http.ApiController
    {
        RegisterHttpClient _registerHttpClient = null;

        public RegisterApiController(RegisterHttpClient registerHttpClient)
        {
            this._registerHttpClient = registerHttpClient;
        }

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage RegisterUser(UserInfo userInfo)
        {
           // var registerHttpClient = new RegisterHttpClient();

            var response = _registerHttpClient.RegisterUser(userInfo);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPut]
        [Route("api/register")]
        public HttpResponseMessage ActivateRegisteredUser(OtpRequest request)
        {
            //var registerHttpClient = new RegisterHttpClient();

            var response = _registerHttpClient.ActivateRegisteredUser(request);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Authenticate(LoginRequest login)
        {
           // var registerHttpClient = new RegisterHttpClient();

            var response = _registerHttpClient.Authenticate(login);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPost]
        [Route("api/passwordmanage")]
        public HttpResponseMessage ChangePasswordOnFirstLogin(LoginRequest login)
        {
            //var registerHttpClient = new RegisterHttpClient();

            var response = _registerHttpClient.ChangePasswordOnFirstLogin(login);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }
    }
}