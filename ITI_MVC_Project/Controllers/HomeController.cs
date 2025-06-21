using System.Diagnostics;
using ITI_MVC_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();  
        }

        public IActionResult Privacy()
        {
            //from session
            string insNameSes = HttpContext.Session.GetString("InstructorName");
            string insDeptSes = HttpContext.Session.GetString("InstructorDepartment");

            //from cookies
            string insNameCo = HttpContext.Request.Cookies["InstructorName"];
            string insDeptCo = HttpContext.Request.Cookies["InstructorDepartment"];
            return Content($"From Session \n Instructor Name: {insNameSes}, Instructor Department: {insDeptSes} \nFrom Cookies \n " +
                $"Instructor Name: {insNameCo}, Instructor Department: {insDeptCo}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
