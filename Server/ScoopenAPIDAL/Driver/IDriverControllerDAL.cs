using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ScoopenAPIModals.Driver;

namespace ScoopenAPIDAL.Driver
{
   public interface IDriverControllerDAL
    {
        List<DriverViewModel> DriversList();
    }
}
