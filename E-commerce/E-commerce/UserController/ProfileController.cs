using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.UserController
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult ProfileView()
        {
            return View();
        }

        public ActionResult GetUserById()
        {
            UsersModel data = new UsersModel();
            UserDL userDL = new UserDL();
            data = userDL.GetAllUsersById((int)Session["UserId"]);

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateProfileById(UsersModel data)
        {

            UserDL userDL = new UserDL();
            bool h = userDL.UpdateProfileByUserId(data);

            return Json(true, JsonRequestBehavior.AllowGet);

        }

        
    }
}