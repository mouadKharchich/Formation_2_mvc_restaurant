using Microsoft.AspNetCore.Mvc;

namespace Restaurant_MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article()
        {
            return View();  
        }
    }
}
