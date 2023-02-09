using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class CustomerController : Controller
    {       
        public IActionResult Index()
        {
            
            return View(Kund.getAllCustomers());
        }
        
        public IActionResult EditCustomerAuto(int customerNr)
        {

            return View(Kund.getOneCustomer(customerNr));
        }

        [HttpPost]
        public IActionResult saveCustomer(Kund k)
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

        public IActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult saveNewCustomer(Kund ny)
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

        public IActionResult deleteCustomer(int customerNr)
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
    }
}
