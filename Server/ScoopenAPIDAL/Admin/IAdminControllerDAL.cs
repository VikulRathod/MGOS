using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoopenAPIModals.Admin;

namespace ScoopenAPIDAL.Admin
{
   public interface IAdminControllerDAL
    {
        int RegisterAdmin(string firstName, string lastName, string email, string mobile ,string address,string zipcode,int countryid,int cityid,int stateid, string otp);

        int ActivateRegisteredAdmin(string mobile, string password, string email, string otp);

        void SaveOtpInDatabase(string mobile, string email, string otp);

        string GetOtpFromDatabase(string mobile, string email);

        User Authenticate(string username, string password);

        int ChangePasswordOnFirstLogin(string userName, string currentPassword, string newPassword);
    }
}
