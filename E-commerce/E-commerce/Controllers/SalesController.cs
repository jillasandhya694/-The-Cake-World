using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult SalesView()
        {
            return View();
        }

        public ActionResult GetOrdersByStatus(int Status)
        {
            OrdersDL ordersDL = new OrdersDL();
            List<Orders> listOrders = ordersDL.GetOrdersByStatus(Status);
            return Json(listOrders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateStatusByOrderId(int OrderId)
        {
            OrdersDL ordersDL = new OrdersDL();
            bool data = ordersDL.UpdateStatusByOrderId(OrderId);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}