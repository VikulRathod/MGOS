using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIModals.Driver
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string BoxSize { get; set; }
        public string VehicleTypeImage { get; set; }
        public int RatePerKm { get; set; }
        public int Offer { get; set; }

    }
}
