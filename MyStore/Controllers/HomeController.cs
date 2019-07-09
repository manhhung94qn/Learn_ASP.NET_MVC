using MyStore.Models;
using MyStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.Controllers
{
    public class HomeController : Controller
    {
        List<ProductModel> ProductList;
        IProduct productService;
        public HomeController()
        {
            this.productService = new ProductRepository(new MyshopContext());

        }
        public ActionResult Index()
        {
            this.ProductList = this.productService.getAllProduct().ToList();
            ViewBag.ProductList = this.ProductList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.ListProduct = this.ProductList;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}