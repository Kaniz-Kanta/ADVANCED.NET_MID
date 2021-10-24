using Product_Category.Models;
using Product_Category.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        public ActionResult HomeForCustomer()
        {
            Database database = new Database();
            var products = database.Products.GetAllProduct();
            return View(products);
        }
        public ActionResult AddToCart(int id)
        {

            if (ModelState.IsValid)
            {
                Database db = new Database();
                var p = db.Products.GetProductById(id);

                if (Session["Cart_Product"] == null)
                {
                    List<Product> CartProduct = new List<Product>();

                    CartProduct.Add(p);
                    string json = new JavaScriptSerializer().Serialize(CartProduct);
                    Session["Cart_Product"] = json;
                    return RedirectToAction("HomeForCustomer");
                }
                else
                {
                    var Cart = Session["Cart_Product"];
                    var CartProduct = new JavaScriptSerializer().Deserialize<List<Product>>(Cart.ToString());


                    CartProduct.Add(p);
                    string json = new JavaScriptSerializer().Serialize(CartProduct);
                    Session["Cart_Product"] = json;
                    return RedirectToAction("HomeForCustomer");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Cart()
        {
            if (Session["Cart_Product"] == null)
            {

            }
            else
            {
                var Cart = Session["Cart_Product"];
                var CartProduct = new JavaScriptSerializer().Deserialize<List<Product>>(Cart.ToString());
                return View(CartProduct);
            }

            return View();
        }
        [HttpPost]
        public ActionResult Confirm_Order(Product p)
        {

            Database db = new Database();
            DateTime now = DateTime.Now;
            string Date = now.ToString("YYYY-MM-dd");
            string Time = now.ToString("aa:bb");
            db.Orders.AddOrder(Date, Time, p.ProductName);
            return RedirectToAction("HomeForCustomer");

        }
    }
}