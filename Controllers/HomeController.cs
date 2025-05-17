using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoleBasedProductAPI.Models;

namespace RoleBasedProductAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult login()
        {
            return View("views/Home/Account/login.cshtml");
        }

        public IActionResult Register()
        {
            return View("views/Home/Account/Register.cshtml");
        }
         public IActionResult Dashboard()
        {
            return View("views/Home/Products/dashboard.cshtml");
        }
         public IActionResult Products1()
        {
            return View("views/Home/Products/products.cshtml");
        }
        
        public IActionResult Reports()
        {
            return View("views/Home/Products/reports.cshtml");
        }
        
        public IActionResult StockIn()
        {
            return View("views/Home/Products/stock-in.cshtml");
        }
        
        public IActionResult StockOut()
        {
            return View("views/Home/Products/stock-out.cshtml");
        }
        
        public IActionResult Settings()
        {
            return View("views/Home/Products/settings.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
