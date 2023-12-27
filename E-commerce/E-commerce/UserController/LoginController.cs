using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.UserController
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View("LoginLayout");
        }


    }
}