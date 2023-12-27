using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.UserController
{
    public class DetailPageViewController : Controller
    {
        // GET: DetailPageView
        public ActionResult ProDetailPageView(int ProductId)
        {
            return View(ProductId);
        }

       
    }
}