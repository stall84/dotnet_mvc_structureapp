using Ode_To_Food.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ode_To_Food.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Felinis Pizza", Cuisine= CuisineType.Pizza},
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine= CuisineType.French},
                new Restaurant { Id = 3, Name = "Sweet Auburn BBQ", Cuisine= CuisineType.American}
            };

        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
