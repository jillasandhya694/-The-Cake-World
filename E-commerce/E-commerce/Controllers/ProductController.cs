using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductView()
        {
            return View();
        }

        public ActionResult GetProducts()
        {
            List<ProductsModel> listproducts = new List<ProductsModel>();
            ProductsDL productsDL = new ProductsDL();
            listproducts = productsDL.GetAllProducts();

            return Json(listproducts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllProductsByCategory(int CategoryId)
        {
           // List<ProductsModel> data = new List<ProductsModel>();
            ProductsDL productsDL = new ProductsDL();
            List<ProductsModel> data = productsDL.GetAllProductsByCategory(CategoryId);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateProductActive(bool IsActive, int ProductId) 
        {
            ProductsDL productsDL = new ProductsDL();
            bool data = productsDL.UpdateActiveProductByProductId(IsActive, ProductId);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductsDetails(int ProductId) 
        {
            ProductsDL productsDL = new ProductsDL();
            ProductDetailsModel data = new ProductDetailsModel();
            data.data1 = productsDL.GetProductsById(ProductId);
            data.data2 = productsDL.GetProductsPriceListById(ProductId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveProductsDetails(ProductDetailsModel data)
        {
            ProductsDL productsDL = new ProductsDL();

           productsDL.UpdateProductsByProductsId(data.data1);

            foreach (var item in data.data2)
            {
                if (item.PPListId == 0)
                {
                    productsDL.InsertProductPriceListing(item);
                }
                else {
                    productsDL.UpdateProductsPriceListByPPI(item);
                }
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}