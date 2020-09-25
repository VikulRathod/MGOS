using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ScoopenAPIModals.Notifications;
using ScoopenAPIModals.Admin;
using ScoopenModals.Account;
using ScoopenAPIModals.Admin;

namespace RegistrationAndLogin.Service_References.Admin
{
    interface IAdminRegisterHttpClient
    {

        HttpResponseMessage RegisterAdmin(Admins admins);
        HttpResponseMessage ActivateRegisteredAdmin(OtpRequest request);
        HttpResponseMessage Authenticate(AdminLoginRequest login);
        HttpResponseMessage ChangePasswordOnFirstLogin(AdminLoginRequest login);
    }
}
