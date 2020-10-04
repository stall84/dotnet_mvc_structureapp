using Ode_To_Food.Data.Models;
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
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();                                                            // Instantiate a local object 'model' that pulls the GetAll method off our Interface
            return View(model);                                                                 // Pass the local model instance into the View being returned
        }

        [HttpGet]
        public ActionResult Details(int id)                                                     // Will associate integer specified in route as id parameter
        {                                                                                       // We will want to add some logic to check for the existence of a restaurant Id in database so that if it doesn't
            var model = db.Get(id);                                                             // exist, we will fail-soft in some way instead of throwing an exception or crashing
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]                                                                       // Validates the token MVC adds to the related form 

                                                                                                         // Passing in a Restaurant object will have the MVC framework 'look' for properties of the same name as the
                                                                                                         // properties/fields on the Restaurant class (namespace Ode..Data/Models/Restaurant.cs) which will be coming in
                                                                                                         // on the request body from the form-post. This is known as 'Model-Binding' in MVC framework 
        public ActionResult Create(Restaurant restaurant)                   
        {
            //if ( String.IsNullOrEmpty(restaurant.Name))                                                 // Create an 'explicit' validation check for the user input coming back on the form post request obj
            //{                                                                                           // This checks if the name value is empty or null and returns an AddModelError for the Name form field, with error message
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");              // This explicit way of defining a validation check is fine, but Data-Annotations on the Model/ViewModel 
            //}                                                                                           // is easier and less code (so commented out)

            if ( ModelState.IsValid )                                                                     // After refactor, this is checking the Data-Annotation validation added in the Restaurant Model   
            {
                db.Add(restaurant);                                                                       // If validation passes (IsValid == true), add the new restaurant object into the db and 
                return RedirectToAction("Details", new { id = restaurant.Id });                           // return Details action/view passing along the newly created restaurant Id in form of anonymous object
            }
            return View();                                                                                // Otherwise: re-return the user the View with the form to try again                                 
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]                                                                          // In this case we're going to just use another Post method on the Edit action instead of put or patch
        [ValidateAntiForgeryToken]                                                          // Pass in the restaurant class as data model again
                                                                                            // We will be required to create a new property on our Interface and Model to implement Update.
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);                                                      // Pass in the restaurant object newly editewd and matched via model-binding to Update method on our Interface/Model
                return RedirectToAction("Details", new { id = restaurant.Id });             // Redirect 
            }
            
            return View(restaurant);
            
        }


    }
}