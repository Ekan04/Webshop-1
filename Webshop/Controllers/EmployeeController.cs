using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email)
        {
            Employee.GetEmployeeByEmail(email);
            return View();
        }
    }
}
