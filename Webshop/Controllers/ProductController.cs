using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View(Products.getAllProducts());
        }

        public IActionResult Edit(int productNr)
        {
            return View(Products.getOneProduct(productNr));
        }

        [HttpPost]
        public IActionResult saveProduct(Products p)
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

        public IActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult saveNewProduct(Products ny)
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

        public IActionResult removeProduct(int productNr)
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
    }
}
