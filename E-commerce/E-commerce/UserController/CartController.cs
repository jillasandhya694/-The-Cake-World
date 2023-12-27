using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.UserController
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult CartView()
        {
            return View();
        }

        public ActionResult InsertintoCartTable(CartModel PPdata)
        {
            CartDL cartDL = new CartDL();
            bool data = cartDL.InsertintoCartTable(PPdata);
            Session["CartCount"] = (int)Session["CartCount"] + 1;
            return Json((int)Session["CartCount"], JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCartDetails()
        {
            
            CartDL cartDL = new CartDL();
            List<CartModel> listCart = cartDL.GetCartDetails((int)Session["UserId"]);
            return Json(listCart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemovefromCartTable(int CardId)
        {
            CartDL cartDL = new CartDL();
            bool data = cartDL.RemovefromCartTable(CardId);
            Session["CartCount"] = (int)Session["CartCount"] - 1;
            return Json((int)Session["CartCount"], JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertintoOrders()
        {
            CartDL cartDL = new CartDL();
            bool data = cartDL.InsertintoOrders((int)Session["UserId"]);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateQuantityByCartId(int Quantity, int CardId)
        {
            CartDL cartDL = new CartDL();
            bool data = cartDL.UpdateQuantityByCartId(Quantity, CardId);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
