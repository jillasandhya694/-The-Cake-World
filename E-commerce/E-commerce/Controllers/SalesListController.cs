using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class SalesListController : Controller
    {
        // GET: SalesList
        public ActionResult SalesListView(int OrderId)
        {
            return View(OrderId);
        }
    }
}