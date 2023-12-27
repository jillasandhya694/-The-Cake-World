using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce.DataLayer;

namespace E_commerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllActiveCategory()
        {
            List<Category_Model> listCategory = new List<Category_Model>();
            CategoryDL categoryDL = new CategoryDL();
            listCategory = categoryDL.GetAllActiveCategory();

            return Json(listCategory, JsonRequestBehavior.AllowGet);

        }

    }
}