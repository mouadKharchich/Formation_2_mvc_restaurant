using Restaurant_MVC.Models;

namespace Restaurant_MVC.Abstructs
{
    public interface IRestaurantService
    {
        List<Restaurant> GetRestaurants();

        Restaurant GetRestaurant(int id);

        Restaurant CreateRestaurant(Restaurant restaurant);

        Restaurant UpdateRestaurant(Restaurant newRestaurant);

        Restaurant DeleteRestaurant(int id);
    }
}
