using ScoopenAPIDAL.Driver;
using ScoopenAPIModals.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIBLL
{
   public class DriverControllerBLL
    {
        IDriverControllerDAL _driverControllerDAL = null;
        public DriverControllerBLL(IDriverControllerDAL driverControllerDAL)
        {
            this._driverControllerDAL = driverControllerDAL;
        }

        public List<DriverViewModel> DriversList()
        {
           return _driverControllerDAL.DriversList();
        }
    }
}
