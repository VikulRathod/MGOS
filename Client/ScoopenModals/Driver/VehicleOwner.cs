using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIModals.Driver
{
   public class VehicleOwner
    {
        public int DriverId{ get; set; }
        public int UserId{ get; set; }
        public string Pancard { get; set; }
        public string License{ get; set; }
        public string Location{ get; set; }
        public bool IsActive{ get; set; }
        public decimal AvgRating{ get; set; }
        public int NoOfTrips{ get; set; }
        public int VehicleId { get; set; }
    }
}
