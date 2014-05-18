using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Book",
                url: "Libriary/User/{userId}/Books/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Books",
                url: "Libriary/Books/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}
