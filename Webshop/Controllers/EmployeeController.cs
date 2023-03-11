using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Drawing.Printing;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpContextAccessor contxt;
        
        public EmployeeController(IHttpContextAccessor httpContextAccessor) 
        { 
            contxt = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email)
        {   
            Employee employee = new Employee();
            employee = Employee.GetEmployeeByEmail(email);
            if (employee.Email == null)
            {
                ViewBag.felmeddelande = "Wrong email or password";
                return View("LoginPartial");
            }
            contxt.HttpContext.Session.SetString("employeeName", employee.Name);
            contxt.HttpContext.Session.SetString("employeeRole", employee.Role);

            return View("LoggedinTest");
        }

        public IActionResult LoggedinTest()
        {
            return View();
        }

        public IActionResult logout()
        {
            contxt.HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
