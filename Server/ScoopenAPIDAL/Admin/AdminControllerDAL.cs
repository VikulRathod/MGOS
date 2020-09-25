using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoopenAPIDAL.Admin;
using ScoopenAPIModals.Admin;
using System.Data.SqlClient;
using System.Data;

namespace ScoopenAPIDAL.Admin
{
    public class AdminControllerDAL : IAdminControllerDAL
    {
      public  int RegisterAdmin(string firstName, string lastName, string email, string mobilenumber, string address, string zipcode, int countryid, int cityid, int stateid, string otp)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteScoopenDB.ExecuteReader(con, ScoopenDB.spRegisterUser,
                     new SqlParameter() { ParameterName = "@FirstName", Value = firstName },
                     new SqlParameter() { ParameterName = "@LastName", Value = lastName },
                     new SqlParameter() { ParameterName = "@Email", Value = email },
                     new SqlParameter() { ParameterName = "@MobileNumber", Value = mobilenumber },
                     new SqlParameter() { ParameterName = "@Address", Value = address },
                     new SqlParameter() { ParameterName = "@Zipcode", Value = zipcode },
                     new SqlParameter() { ParameterName = "@CountryId", Value = countryid },
                     new SqlParameter() { ParameterName = "@CityId", Value = cityid },
                     new SqlParameter() { ParameterName = "@StateId", Value = stateid },
                     new SqlParameter() { ParameterName = "@Otp", Value = otp });

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (int)reader[0];
                    }
                }
            }

            return -1;

        }
        public int ActivateRegisteredAdmin(string mobile, string password, string email, string otp)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteScoopenDB.ExecuteReader(con, ScoopenDB.spActivateRegisteredUser,
                    new SqlParameter() { ParameterName = "@Mobile", Value = mobile },
                    new SqlParameter() { ParameterName = "@Password", Value = password },
                    new SqlParameter() { ParameterName = "@Email", Value = email },
                    new SqlParameter() { ParameterName = "@Otp", Value = otp });

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (int)reader[0];
                    }
                }
            }
            return -1;
        }

        public User Authenticate(string username, string password)
        {
            User user = new User();

            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteScoopenDB.ExecuteReader(con, ScoopenDB.spAuthenticateUser,
                     new SqlParameter() { ParameterName = "@UserName", Value = username },
                     new SqlParameter() { ParameterName = "@Password", Value = password });


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.AccountLocked = (int)reader["AccountLocked"];
                        user.IsAuthenticated = (int)reader["Authenticated"];
                        user.RetryAttempts = (int)reader["RetryAttempts"];
                    }
                }
            }

            return user;

        }

        public int ChangePasswordOnFirstLogin(string userName, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string GetOtpFromDatabase(string mobile, string email)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlParameter otp = new SqlParameter() { ParameterName = "@Otp", DbType = DbType.String, Size = 6, Direction = ParameterDirection.Output };
                SqlDataReader reader = ExecuteScoopenDB.ExecuteReader(con, ScoopenDB.spGetOtpFromDatabase,
                    new SqlParameter() { ParameterName = "@Mobile", Value = mobile },
                    new SqlParameter() { ParameterName = "@Email", Value = email }, otp);
                return otp.Value.ToString();
            }

            return string.Empty;
        }

        public void SaveOtpInDatabase(string mobile, string email, string otp)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteScoopenDB.ExecuteReader(con, ScoopenDB.spSaveOtpInDatabase,
                    new SqlParameter() { ParameterName = "@Mobile", Value = mobile },
                    new SqlParameter() { ParameterName = "@Email", Value = email },
                    new SqlParameter() { ParameterName = "@Otp", Value = otp });
            }
        }
    }
}
