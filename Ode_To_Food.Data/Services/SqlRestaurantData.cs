using Ode_To_Food.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_To_Food.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {   
        // This is a 'mirror' class/model of the InMemoryRestaurantData class, but made for our sql database
        // With corresponding database read/write actions instead of for mock-up in-memory

        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)             // Initialize with a constructor that takes a database object of the DbContext type
        {                                                           // Set private readonly field appropriately
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {                                                           // The DbSET method is made available via our constructor injection of OTFDbContext
            
        }

        public Restaurant Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
