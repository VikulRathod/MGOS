using ScoopenAPIModals.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIDAL.Driver
{
   public interface IDriverControllerDAL
    {
        List<DriverViewModel> DriversList();
    }
}
