using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ScoopenAPIModals.Driver;

namespace ScoopenAPIDAL.Driver
{
    public class DriverControllerDAL : IDriverControllerDAL
    {
        public List<DriverViewModel> DriversList()
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteScoopenDB.ExecuteReader(con, ScoopenDB.spDriversList);

                List<DriverViewModel> driverlist = new List<DriverViewModel>();
                while (reader.Read())
                {
                    DriverViewModel d = new DriverViewModel();
                    d.FullName = reader["fullname"].ToString();
                    d.Photo = reader["photo"].ToString();
                    d.Nooftrips = Convert.ToInt32(reader["Nooftrips"]);
                    d.AvgRating = Convert.ToDecimal(reader["fullname"]);
                    d.vTypename = reader["vtypename"].ToString();
                    d.RatePerKm = Convert.ToDecimal(reader["rateperkm"]);
                    driverlist.Add(d);
                }

                return driverlist;
            }

        }
    }
}
