using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserView()
        {
            return View();
        }

        public ActionResult GetUser()
        {
            List<UsersModel> listUsers = new List<UsersModel>();
            UserDL userDL = new UserDL();
            listUsers = userDL.GetAllUsers();
            return Json(listUsers, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateActive(bool IsActive, int UserId)
        {

            UserDL userDL = new UserDL();
            bool data = userDL.UpdateActiveByUserId(IsActive, UserId);

            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateBlock(bool IsBlocked, int UserId)
        {

            UserDL userDL = new UserDL();
            bool data = userDL.UpdateBlockByUserId(IsBlocked, UserId);

            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetUsersByUserName(string UserName, string Password)
        {
            UsersModel data = new UsersModel();
            UserDL userDL = new UserDL();
            data = userDL.GetUserByUserName(UserName);

            if (data.UserId == 0)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else if (Password == data.Password)
            {
                Session["UserId"] = data.UserId;
                Session["UserName"] = data.UserName;
                Session["Password"] = data.Password;
                Session["EmailId"] = data.EmailId;
                Session["CartCount"] = data.CartCount;
                return Json(2, JsonRequestBehavior.AllowGet);

            }
            else {
                return Json(1, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult SignOut()
        {
            Session.Abandon();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    
    }
}    
