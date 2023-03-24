using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Restaurant_MVC.Abstructs;
using Restaurant_MVC.Models;

namespace Restaurant_MVC.Controllers
{
   // [Route("Restaurant")]
   // [ResponseHeaderAttribut("customer_id","value_id")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        // [Route("/Test")] //=> Restaurant/Test
        //[Route("/Test/Index")]
        // [Route("Test/Index/{id?}")]
        // [Route("/Test")]

        // [Route("Index")]
        public IActionResult Index()
        {
            /* Restaurant model = new Restaurant()
             {
                 Id=2,
                 Name="name2",
                 Description="Description2"
             };
             //ViewBag.Model = model;  
             //TempData["Message"] = "This is my Message";
             TempData["Message"] = null;*/
            var Restaurants = restaurantService.GetRestaurants();
            
            
            return View(Restaurants);
        }

        // [Route("/Detail/{id?}")]
        public IActionResult Detail(int id)
        {
            /*var list=GetAll();
            var model = list.FirstOrDefault(r=>r.Id==id);*/
            return FindRestaurant(id);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant newRestaurant)
        {
            if(ModelState.IsValid)
            {
                var restaurant = restaurantService.CreateRestaurant(newRestaurant);
                return RedirectToAction(nameof(Index));

            }
            return View();

        }

      

        public IActionResult Delete(int id)
        {
            return FindRestaurant(id);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
          
                restaurantService.DeleteRestaurant(id);
                return RedirectToAction(nameof(Index)); 

        }


        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {

            return FindRestaurant(id);

        }

        [HttpPost]
        public IActionResult Edit(Restaurant updateRestaurant)
        {
            if (ModelState.IsValid)
            {
                var restaurant = restaurantService.UpdateRestaurant(updateRestaurant);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private IActionResult FindRestaurant(int id)
        {
            var restaurant = restaurantService.GetRestaurant(id);
            if (restaurant == null)
            {
                return RedirectToAction(nameof(NotFound));
            }
            return View(restaurant);
        }

        /* public List<Restaurant> GetAll()
         {
             return new List<Restaurant>
             {
                 new Restaurant
                 {
                     Description="Description",
                     Id=1,
                     Name="Name"
                 }
             };
         }*/
    }
}
