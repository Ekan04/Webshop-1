using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class CustomerController : Controller
    {       
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                return View(Kund.getAllCustomers());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }
        
        public IActionResult EditCustomerAuto(int customerNr)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                return View(Kund.getOneCustomer(customerNr));
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        [HttpPost]
        public IActionResult saveCustomer(Kund k)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                if (Kund.saveEditedCustomer(k) == true)
                {
                    ViewBag.Meddelande = "Redigeringen har sparats";
                }
                else
                {
                    ViewBag.Meddelande = "Redigeringen har inte sparats";
                }
                return View("Index", Kund.getAllCustomers());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            } 
        }

        public IActionResult NewCustomer()
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
        public IActionResult saveNewCustomer(Kund ny)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                if (Kund.saveNewCustomer(ny) == true)
                {
                    ViewBag.Meddelande = "Den nya kunden har sparats";
                }
                else
                {
                    ViewBag.Meddelande = "Den nya kunden har inte sparats";
                }
                return View("Index", Kund.getAllCustomers());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public IActionResult deleteCustomer(int customerNr)
        {
            if (HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                if (Kund.removeCustomer(customerNr) == true)
                {
                    ViewBag.Meddelande = "Kunden med CustomerNr: " + customerNr + " har tagits bort";
                }
                else
                {
                    ViewBag.Meddelande = "Kunden har inte tagits bort";
                }
                return View("Index", Kund.getAllCustomers());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }
}
