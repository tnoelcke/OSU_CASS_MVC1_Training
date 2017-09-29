using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTraining
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapMvcAttributeRoutes(); //Enables atribute routing.

            //This one works because it comes before your default route.
            routes.MapRoute(
                name: "Special",
                url: "Classes",
                defaults: new {controller = "Classes", Action = "Details", id = 1}
            );

            //This route looks for the patern String/String/?id (could be string or int)
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //this one doesn't work becaues it comes after your default route.
            routes.MapRoute(
                name: "Special2",
                url: "Students",
                defaults: new {controller = "Students", Action = "Details", id = 1 }
            );
        }
    }
}
