using E_commerce.DataLayer;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        //fix1
        public ActionResult CategoryView()
        {
            return View();
        }

        public ActionResult GetCategory()
        {
            List<Category_Model> listCategory = new List<Category_Model>();
            CategoryDL categoryDL = new CategoryDL();
            listCategory = categoryDL.GetAllCategory();

            return Json(listCategory, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategorybyCategoryId(int CategoryId) {

            Category_Model data = new Category_Model();
            CategoryDL categoryDL = new CategoryDL();
            data = categoryDL.GetCategoryById(CategoryId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateCategoryById(int CategoryId, string Category)
        {
            CategoryDL categoryDL = new CategoryDL();
            bool data = categoryDL.UpdateCategoryByCategoryId( CategoryId, Category);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveCategory(Category_Model data)
        {
            CategoryDL categoryDL = new CategoryDL();
            bool category = categoryDL.InsertintoCategory(data);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateIsActive(int CategoryId, bool IsActive)
        {
            CategoryDL categoryDL = new CategoryDL();
            bool data = categoryDL.UpdateActiveByCategoryId( CategoryId,  IsActive);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }


}