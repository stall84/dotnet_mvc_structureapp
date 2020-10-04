using Ode_To_Food.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_To_Food.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant Get(int id);                                 // Get specific restaurant by integer id that's passed in on query param

        void Add(Restaurant restaurant);                        // Method to implement adding restaurants from our post action methods

        void Update(Restaurant restaurant);                     // Using a Post method in Restaurant Controller. This effectively Updates an edited restaurant
    }
}
