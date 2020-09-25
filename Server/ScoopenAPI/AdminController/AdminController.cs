using ScoopenAPIBLL.Admin;
using ScoopenAPIBLL.Utility;
using ScoopenAPIDAL.Admin;
using ScoopenAPIModals.Admin;
using ScoopenAPIModals.Notifications;
using ScoopenNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScoopenAPI.AdminController
{
    public class AdminController : ApiController
    {
        EmailNotifications emailNotification = new EmailNotifications();
        AdminControllerBLL abll = new AdminControllerBLL(new AdminControllerDAL());
        public HttpResponseMessage RegisterAdmin([FromBody] Admin admin)
        {
            try
            {
                if (admin != null)
                {
                    string otp = new LoginHelper().GenerateRandomOtp();

                    int result = abll.RegisterAdmin(admin.FirstName, admin.LastName, admin.Email, admin.MobileNumber, admin.Address, admin.Zipcode, admin.CountryId, admin.StateId, otp);
                    OtpRequest request = new OtpRequest() { MobileNumber =admin.MobileNumber, Email = admin.Email, Otp = otp };
                    OtpResponse emailresponse = emailNotification.SendOTP(request);

                    abll.SaveOtpInDatabase(admin.MobileNumber, admin.Email, otp);

                    return Request.CreateResponse(HttpStatusCode.OK, emailresponse);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        public HttpResponseMessage ActivateRegisteredAdmin([FromBody] OtpRequest request)
        {
            try
            {
                if (request != null)
                {
                    // Uncomment below line if you want to verify otp sent over sms
                    //OtpResponse smsResponse = notification.VerifyOTP(request);
                    OtpResponse emailResponse = emailNotification.VerifyOTP(request);

                    if (emailResponse.Status == "Success")
                    {

                        string password = new LoginHelper().GeneratePassword(8);

                        int result = abll.ActivateRegisteredAdmin(request.MobileNumber, password, request.Email, request.Otp);

                        // Uncomment below lines if you want to send first time login details over sms

                        //LoginDetails req = new LoginDetails()
                        //{
                        //    From = "VHAASH",
                        //    To = request.Mobile,
                        //    TemplateName = "ScoopenLoginAccount",
                        //    VAR1 = "User",
                        //    VAR2 = request.Mobile,
                        //    VAR3 = password
                        //};

                        //OtpResponse smsResponseLoginDetails = notification.SendLoginDetails(req);

                        LoginDetails emailreq = new LoginDetails()
                        {
                            From = "VHAASH",
                            To = request.Email,
                            TemplateName = "ScoopenLoginAccount",
                            VAR1 = "User",
                            VAR2 = request.MobileNumber,
                            VAR3 = password
                        };

                        OtpResponse emailResponseLoginDetails = emailNotification.SendLoginDetails(emailreq);

                        return Request.CreateResponse(HttpStatusCode.OK, emailResponseLoginDetails);
                    }

                    return Request.CreateErrorResponse(HttpStatusCode.NonAuthoritativeInformation, "OTP Not Matched");
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


    }
}
