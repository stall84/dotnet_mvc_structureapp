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

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);                            // In this mock-up in-memory example (pre sql database) We have to fake some things
            restaurant.Id = restaurants.Max(r => r.Id) + 1;         // The user-form will not supply a new ID number so we create one by Max-methoding
                                                                    // the current list and adding 1 to it
        }


        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Id);
        }
    }
}
