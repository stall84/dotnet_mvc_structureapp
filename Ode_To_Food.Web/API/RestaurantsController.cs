using Ode_To_Food.Data.Models;
using Ode_To_Food.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ode_To_Food.Web.API
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;

        // Building an API we define our methods in context of their associated HTTP Method (GET, POST, ETC) 
        public RestaurantsController(IRestaurantData db)                // Initiate a tracking field for our database
        {
            this.db = db;
        }

        public IEnumerable<Restaurant> Get()                        // Get method that will return an IEnumerable of type Restaurant (Restaurant.cs class in Data Project)
        {                                                           // Get method instantiates our database object as model. Then calls the GetAll method on our Interface
            var model = db.GetAll();
            return model;                                           // An API only needs return the data, not a view
        }
    }
}
