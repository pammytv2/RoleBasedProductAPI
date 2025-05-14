using Microsoft.AspNetCore.Mvc;

namespace RoleBasedProductAPI.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Dashboard()
        {
            return View("~/Views/Products/Dashboard.cshtml");
        }
        
        public IActionResult Products()
        {
            return View("~/Views/Products/Products.cshtml");
        }
        
        public IActionResult Reports()
        {
            return View("~/Views/Products/Reports.cshtml");
        }
        
        public IActionResult StockIn()
        {
            return View("~/Views/Products/StockIn.cshtml");
        }
        
        public IActionResult StockOut()
        {
            return View("~/Views/Products/StockOut.cshtml");
        }
        
        public IActionResult Settings()
        {
            return View("~/Views/Products/Settings.cshtml");
        }
    }
}