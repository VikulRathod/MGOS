using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIModals.Driver
{
   public class DriverViewModel
    {
        public string FullName { get; set; }
        public string Photo { get; set; }
        public int Nooftrips { get; set; }
        public decimal AvgRating { get; set; }
        public string vTypename { get; set; }
        public decimal RatePerKm { get; set; }
    }
}
