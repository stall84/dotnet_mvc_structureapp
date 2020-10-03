using Ode_To_Food.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ode_To_Food.Web.Controllers
{
    public class GreetingController : Controller
    {
        
        public ActionResult Index(string Name)                  // Pass in a string for the parameter you want the framework to locate as a query parameter
        {                                                       
            
            var model = new GreetingViewModel();                // Instantiate a new model object that we've defined properties for in the GreetingViewModel
           
            model.Message = ConfigurationManager.AppSettings["message"];    // Assign the message key we've defined in the web.Config file 
            model.Name = Name;                                  // Assign the incoming query parameter to our model's Name property
            return View(model);
        }
    }
}