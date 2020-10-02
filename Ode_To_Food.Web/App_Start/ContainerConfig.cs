using Autofac;
using Autofac.Integration.Mvc;
using Ode_To_Food.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ode_To_Food.Web
{               
                // Utilizing the AutoFac (Nuget package) API to create a container
                // The container's job is to communicate about & keep track of the 
                // different components and abstractions in the project. Which services you
                // want injected into other pieces of software in this application. The container
                // will then be able to handle resolving dependencies.
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            // First instantiate the autofac api 'builder' container-builder object. 
            //Afterwhich you go about listing the different abstractions in the application
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);          // Scans project for controllers in the assembly - location you pass-in

            // Specific Services you want builder to keep track of
            builder.RegisterType<InMemoryRestaurantData>()                  // Direct autofac container builder to watch for and manage
                .As<IRestaurantData>();                                     // all requests that need to implement IRestaurantData by utilizing the InMemoryRestaurantData type.
                // Here we get the 'magic' of the container/wrapper by instructing it (container-builder)
                // that anywhere in the whole application where an IRestaurantData type implementation 
                // is needed, to use the specified type we put in on the first line (InMemoryRestaurantData).
                

        }                                                                   
    }
}