using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Api;
using ScoopenAPIModals.Driver;
using Newtonsoft.Json;

namespace RegistrationAndLogin.Controllers
{
    public class DriverController : Controller
    {
        DriverApiController driver = new DriverApiController();
        [HttpGet]
        public ActionResult DriverList()
        {
            List<DriverViewModel> list = new List<DriverViewModel>()
;           var response= driver.DriversList();

            if (response != null && response.IsSuccessStatusCode)
            {
               var re= response.Content.ReadAsStringAsync().Result;
               list = JsonConvert.DeserializeObject<List<DriverViewModel>>(re);
                return View(list);

            }

            ModelState.AddModelError("", "please contact to admin.");
            return View();
        }
    }
}