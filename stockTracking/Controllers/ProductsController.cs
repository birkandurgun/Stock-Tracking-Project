using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stockTracking.Models.Entity;
using stockTracking.ViewModals;

namespace stockTracking.Controllers
{
    public class ProductsController : Controller
    {
        stockManagementSystemEntities1 db = new stockManagementSystemEntities1();

        [Authorize]
        public ActionResult ProductList()
        {
            var products = db.products.ToList();
            
            return View(products);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            var categories = db.category.ToList();
            var viewModel = new AddProductViewModel
            {
                ProductModel = new products(),
                Categories = categories.Select(c => new SelectListItem { Text = c.cName, Value = c.cName }).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = db.category.ToList().Select(c => new SelectListItem { Text = c.cName, Value = c.cName }).ToList();
                return View(viewModel);
            }

            if (db.products.Any(p => p.pName == viewModel.ProductModel.pName))
            {
                ModelState.AddModelError("ProductModel.pName", "A product with the same name already exists.");
                viewModel.Categories = db.category.ToList().Select(c => new SelectListItem { Text = c.cName, Value = c.cName }).ToList();
                return View(viewModel);
            }

            db.products.Add(viewModel.ProductModel);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }


        public ActionResult DeleteProduct(string pName)
        {
            var product = db.products.Find(pName);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult GetUpdateProduct(string pName)
        {
            var product = db.products.Find(pName);

            var viewModel = new AddProductViewModel
            {
                ProductModel = product,
                Categories = db.category.Select(c => new SelectListItem { Text = c.cName, Value = c.cName }).ToList()
            };

            return View("UpdateProduct", viewModel);
        }

        public ActionResult UpdateProduct(AddProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = db.category.Select(c => new SelectListItem { Text = c.cName, Value = c.cName }).ToList();
                return View("UpdateProduct", viewModel);
            }

            var existingProduct = db.products.Find(viewModel.ProductModel.pName);

            existingProduct.pDescription = viewModel.ProductModel.pDescription;
            existingProduct.pQuantity = viewModel.ProductModel.pQuantity;
            existingProduct.pPrice = viewModel.ProductModel.pPrice;
            existingProduct.pBrand = viewModel.ProductModel.pBrand;
            existingProduct.pCategory = viewModel.ProductModel.pCategory;

            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

    }
}