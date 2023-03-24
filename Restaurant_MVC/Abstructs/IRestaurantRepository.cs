using Restaurant_MVC.Models;

namespace Restaurant_MVC.Abstructs
{  
        public interface IRestaurantRepository
        {
            List<Restaurant> Restaurants { get; set; }
        }
}
