using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.UserController
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult OrdersView()
        {
            return View();
        }

        public ActionResult GetOrders()
        {

            OrdersDL ordersDL = new OrdersDL();
            List<Orders> listOrders = ordersDL.GetOrders((int)Session["UserId"]);
            return Json(listOrders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrderItems(int OrderId)
        {

            OrdersDL ordersDL = new OrdersDL();
            List<Orders> listOrders = ordersDL.GetOrderItems(OrderId);
            return Json(listOrders, JsonRequestBehavior.AllowGet);
        }
    }
}