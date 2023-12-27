using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration()
        {
            return View("RegistrationLayout");
        }

        public ActionResult InsertUserRegistration(UsersModel userdata) 
        {
            UserDL userDL = new UserDL();
            userDL.InsertUserRegistration(userdata);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}