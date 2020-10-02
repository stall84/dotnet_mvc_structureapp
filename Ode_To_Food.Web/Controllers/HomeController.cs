using Ode_To_Food.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ode_To_Food.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;

        public HomeController()                                                 // Hardcoding a new instance of InMemRest just to model before we have our db set up.. Later will use Dependency Injection
        {

            db = new InMemoryRestaurantData();
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
                                                                                // Passing the IEnumerable created in the mock GetAll method of our mock db to the Index View
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}