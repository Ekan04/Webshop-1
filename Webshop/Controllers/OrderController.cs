using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View(Order.getAllOrders());
        }

        public IActionResult Details(int id)
        {
            return View();
        }

    }
}
