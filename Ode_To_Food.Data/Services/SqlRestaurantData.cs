using Ode_To_Food.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ode_To_Food.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {   
        // This is a 'mirror' class/model of the InMemoryRestaurantData class, but made for our sql database
        // With corresponding database read/write actions instead of for mock-up in-memory

        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)                 // Utilizing Autofac / Dependency Injection. Have the MVC pass in a context of DbContext 
        {                                                               //(instead of instantiating locally i.e. var model = new OdeToFoodDbContext(); ) 
            this.db = db;                                               //Initialize with a constructor that takes a database object of the DbContext type
                                                                        // Set private readonly field appropriately

        }
        public void Add(Restaurant restaurant)
        {                                                               // The DbSET method is made available via our constructor injection of OTFDbContext
            db.Restaurants.Add(restaurant);
            db.SaveChanges();                                           // SaveChanges signals EF to create the new insert or delete or whatever statement & write to the db. otherwise changes aren't made
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.OrderBy(r => r.Name);

            //return from r in db.Restaurants                                   // Alternate EF syntax closer tied to sql
            //       orderby r.Name
            //       select r;


        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);                               // This is a more advanced/elegant method that checks the modifications on an object and updates them      
            entry.State = EntityState.Modified;                             // You could also do just simple db.Name = restaurant.Name though
            db.SaveChanges();
        }
    }
}
