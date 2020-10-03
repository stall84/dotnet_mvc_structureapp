using Ode_To_Food.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ode_To_Food.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)            // We want this controller to implement IRestaurantData Interface at call
        {                                                           // Setting our db field to track the data model (IRestaurantData)
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetAll();                    // Instantiate a local object 'model' that pulls the GetAll method off our Interface
            return View(model);                         // Pass the local model instance into the View being returned
        }

        public ActionResult Details(int id)             // Will associate integer specified in route as id parameter
        {                                               // We will want to add some logic to check for the existence of a restaurant Id in database so that if it doesn't
            var model = db.Get(id);                     // exist, we will fail-soft in some way instead of throwing an exception or crashing
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}