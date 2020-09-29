using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoopenAPIDAL.Driver;
using System.Net.Http;
using ScoopenAPIModals.Driver;

namespace ScoopenAPIBLL
{
   public class DriverControllerBLL
    {
        IDriverControllerDAL _iDriverControllerDAL = null;

        public DriverControllerBLL(IDriverControllerDAL IDriverControllerDAL)
        {
            this._iDriverControllerDAL = IDriverControllerDAL;
        }

        public List<DriverViewModel> DriversList()
        {
           return _iDriverControllerDAL.DriversList();
        }
    }
}
