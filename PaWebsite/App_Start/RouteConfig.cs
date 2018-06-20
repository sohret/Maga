using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PaWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{culture}/{controller}/{action}/{id}",
            //    defaults: new { culture = "az", controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "prod",
            //    url: "{culture}/{controller}/{id}",
            //    defaults: new { controller = "Prod", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "cat",
            //    url: "{culture}/{controller}/{action}/{id}",
            //    defaults: new { culture = "az", controller = "Cat", action = "Index", id = UrlParameter.Optional }
            //    );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index", lang = "en-us" }
            //);

            routes.MapRoute(
               name: "Default",
               url: "{lang}/{action}/{id}",
               defaults: new { lang = "null", controller = "Home", action = "Index", id = UrlParameter.Optional },
               constraints: new { lang = "null|az|ru" }
           );
        }
    }
}
