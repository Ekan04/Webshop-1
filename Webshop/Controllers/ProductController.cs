using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                return View(Products.getAllProducts());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public IActionResult Edit(int productNr)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                return View(Products.getOneProduct(productNr));
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        [HttpPost]
        public IActionResult saveProduct(Products p)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                if (Products.saveEditedProduct(p) == true)
                {
                    ViewBag.Meddelande = "Produkten har sparats";
                }
                else
                {
                    ViewBag.Meddelande = "Produkten har inte sparats";
                }
                return View("Index", Products.getAllProducts());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public IActionResult NewProduct()
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                return View();
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        [HttpPost]
        public IActionResult saveNewProduct(Products ny)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                if (Products.saveNewProduct(ny) == true)
                {
                    ViewBag.Meddelande = "Den nya produkten har sparats";
                }
                else
                {
                    ViewBag.Meddelande = "Den nya produkten har inte sparats";
                }
                return View("Index", Products.getAllProducts());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public IActionResult removeProduct(int productNr)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                if (Products.removeProduct(productNr) == true)
                {
                    ViewBag.Meddelande = "Produkten med ProductNr: " + productNr + " har tagits bort";
                }
                else
                {
                    ViewBag.Meddelande = "Produkten har inte tagits bort"; //haveto juice NOW
                }
                return View("Index", Products.getAllProducts());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }
}
