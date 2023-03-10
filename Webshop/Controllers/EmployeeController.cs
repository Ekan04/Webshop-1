using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Drawing.Printing;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpContextAccessor context;
        
        public EmployeeController(IHttpContextAccessor httpContextAccessor) 
        { 
            context = httpContextAccessor;
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
            context.HttpContext.Session.SetString("employeeName", employee.Name);
            context.HttpContext.Session.SetString("employeeRole", employee.Role);

            return View("LoggedinTest");
        }

        public IActionResult LoggedinTest()
        {
            return View();
        }
    }
}
