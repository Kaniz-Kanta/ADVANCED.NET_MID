using Product_Category.Models;
using Product_Category.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Category.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database database = new Database();
            var products = database.Products.GetAllProduct();
            return View(products);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {

            if (ModelState.IsValid)//use for validation
            {
                Database database = new Database();
                database.Products.AddProduct(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database database = new Database();
            var s = database.Products.GetProductById(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {

            if (ModelState.IsValid)//use for validation
            {
                Database database = new Database();
                database.Products.UpdateProduct(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Database database = new Database();
            database.Products.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}