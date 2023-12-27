using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.UserController
{
    public class StuffsController : Controller
    {
        // GET: Stuffs
        public ActionResult PageView(int CategoryId)
        {
            return View(CategoryId);
        }

        public ActionResult GetAllActiveProductsByCategory(int CategoryId)
        {
            
            ProductsDL productsDL = new ProductsDL();
            List<ProductsModel> list = productsDL.GetAllActiveProductsByCategory(CategoryId);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

       

    }
}