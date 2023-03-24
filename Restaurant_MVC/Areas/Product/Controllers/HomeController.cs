using Microsoft.AspNetCore.Mvc;

namespace Restaurant_MVC.Areas.Product.Controllers
{
    [Area("Product")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
