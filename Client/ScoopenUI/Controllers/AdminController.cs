using ScoopenAPIModals.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Api;
using RegistrationAndLogin.AdminApi;
using ScoopenAPIModals.Notifications;
using System.Web.Security;

namespace RegistrationAndLogin.Controllers
{
    public class AdminController : Controller
    {
        AdminRegisterApiController registerapicontroller = new AdminRegisterApiController();
        // GET: Admin
        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegister([Bind(Exclude = "AdminId")] Admins Admins)
        {
            try
            {
                var response = registerapicontroller.RegisterAdmin(Admins);

                if (response != null && response.IsSuccessStatusCode)
                {
                    Session["RegisteredUserDetails"] = Admins;
                    return RedirectToAction("ConfirmRegister");
                }

                ModelState.AddModelError("FirstName", "Error in registration");
            }
            catch(Exception e)
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmRegister(string otp)
        {
            var userDetails = (Admins)Session["RegisteredUserDetails"];

            if (userDetails != null)
            {
                OtpRequest otpRequest = new OtpRequest()
                {
                    Email = userDetails.Email,
                    Mobile = userDetails.MobileNumber,
                    Otp = otp,
                    SessionId = string.Empty // this is required only to verify otp sent over sms, if we have used otp service
                };

                var response = registerapicontroller.ActivateRegisteredAdmin(otpRequest);

                if (response != null && response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "We have sent you login details on your email and mobile.";
                }
                else
                {
                    ViewBag.SendOtpAgain = true;
                }
            }

            ModelState.AddModelError("otp", "Error in otp confirmation");
            return View();
        }

        [HttpGet]
        public ActionResult ResendOtp()
        {
            // Logic to send otp details one more time
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginRequest login)
        {
            // use to hash password
            //string pwd = Crypto.Hash(login.Password);

            var response = registerapicontroller.Authenticate(login);

            if (response != null && response.IsSuccessStatusCode)
            {
                int timeout = 20;
                var ticket = new FormsAuthenticationTicket(login.Username, true, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                Session["UserName"] = login.Username;

                // call change passwor method on first time login
                //return RedirectToAction("ChangePassword");

                return RedirectToAction("Welcome", "Home");
            }
            else
            {
                ViewBag.LoginError = "Error in login";
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            if (newPassword == confirmNewPassword)
            {
                string userName = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;

                // use Crypto.Hash(newPassword)  to hash password
                AdminLoginRequest request = new AdminLoginRequest() { Username = userName, Password = newPassword };

                var response = registerapicontroller.ChangePasswordOnFirstLogin(request);

                if (response != null && response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Welcome", "Home");
                }
            }
            return View();
        }

    }
}