using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("employeeRole") == "Admin")
            {
                return View(Order.getAllOrders());
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public IActionResult Details(int id)
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

    }
}
