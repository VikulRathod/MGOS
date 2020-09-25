using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIModals.Admin
{
   public class Admin
    {
        public byte AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string Otp { get; set; }

    }
}
