using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stockTracking.Models.Entity;

namespace stockTracking.Controllers
{
    public class CategoryController : Controller
    {
        stockManagementSystemEntities1 db = new stockManagementSystemEntities1();
        public ActionResult CategoryList()
        {
            var categories = db.category.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (db.category.Any(c => c.cName == category.cName))
            {
                ModelState.AddModelError("cName", "A product with the same name already exists.");
                return View(category);
            }
            db.category.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(string cName)
        {
            var categoryToDelete = db.category.FirstOrDefault(c => c.cName == cName);

            db.category.Remove(categoryToDelete);
            db.SaveChanges();

            return RedirectToAction("CategoryList");
        }

    }
}