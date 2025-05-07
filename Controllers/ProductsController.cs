using Microsoft.AspNetCore.Mvc;

namespace RoleBasedProductAPI.Controllers
{
    public class ProductsController1 : Controller
    {
        public IActionResult Products()
        {
            return View("views/Products/Products.cshtml");
        }
    }
}
