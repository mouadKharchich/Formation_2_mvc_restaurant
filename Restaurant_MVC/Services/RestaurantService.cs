using Restaurant_MVC.Abstructs;
using Restaurant_MVC.Models;

namespace Restaurant_MVC.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            int id = restaurantRepository.Restaurants.Max(x => x.Id) + 1;
            restaurant.Id = id;
            restaurantRepository.Restaurants.Add(restaurant);
            return restaurant;

        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurant(id);

            if (restaurant != null)
            {
                restaurantRepository.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetRestaurant(int id)
        {

            return restaurantRepository.Restaurants.Where(r => r.Id == id).FirstOrDefault();
        }

        public List<Restaurant> GetRestaurants()
        {
            return restaurantRepository.Restaurants.ToList();
        }

        /// <summary>
        /// update restaurant 
        /// </summary>
        /// <param name="newRestaurant"></param>
        /// <returns></returns>
        public Restaurant UpdateRestaurant(Restaurant newRestaurant)
        {
            var restaurant = GetRestaurant(newRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = newRestaurant.Name;
                restaurant.Description = newRestaurant.Description;
            }
            return restaurant;
        }
    }
}
