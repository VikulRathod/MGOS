using ScoopenAPIDAL.Admin;
using ScoopenAPIModals.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIBLL.Admin
{
   public class AdminControllerBLL
    {
        IAdminControllerDAL _iAdminControllerDAL;
        public AdminControllerBLL(IAdminControllerDAL iAdminControllerDAL)
        {
            _iAdminControllerDAL = iAdminControllerDAL;

        }

        public int RegisterAdmin(string firstName, string lastName, string email, string mobile, string address, string zipcode, int countryid, int cityid, int stateid, string otp)
        {
            return _iAdminControllerDAL.RegisterAdmin( firstName,lastName,email, mobile, address, zipcode, countryid, cityid,stateid,otp);
        }
        public int ActivateRegisteredAdmin(string mobile, string password, string email, string otp)
        {
            return _iAdminControllerDAL.ActivateRegisteredAdmin(mobile, password, email, otp);
        }

        public int RegisterAdmin(string firstName, string lastName, string email, string mobileNumber, string address, string zipcode, int? countryId, int? stateId, string otp)
        {
            throw new NotImplementedException();
        }

        public void SaveOtpInDatabase(string mobile, string email, string otp)
        {
            _iAdminControllerDAL.SaveOtpInDatabase(mobile, email, otp);
        }
        public string GetOtpFromDatabase(string mobile, string email)
        {
            return _iAdminControllerDAL.GetOtpFromDatabase(mobile, email);
        }
        public User Authenticate(string username, string password)
        {
            return _iAdminControllerDAL.Authenticate(username, password);
        }

        public int ChangePasswordOnFirstLogin(string userName, string currentPassword, string newPassword)
        {
            return _iAdminControllerDAL.ChangePasswordOnFirstLogin(userName, currentPassword, newPassword);
        }


    }
}
