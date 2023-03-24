using Restaurant_MVC.Abstructs;
using Restaurant_MVC.Models;

namespace Restaurant_MVC.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public List<Restaurant> Restaurants { get; set; }

        public RestaurantRepository()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="restaurant1",Description="Description1"},
                new Restaurant{Id=2,Name="restaurant2",Description="Description2"},
                new Restaurant{Id=3,Name="restaurant3",Description="Description3"}
            };
        }
    }
}
