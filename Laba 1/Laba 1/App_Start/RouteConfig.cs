using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Laba_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Calculator-Calc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Calculator", action = "Calc", id = UrlParameter.Optional }
            );

           routes.MapRoute(
               name: "Calculator-Result",
               url: "Calculator/Result",
               defaults: new { controller = "Calculator", action = "Result", id = UrlParameter.Optional }
           );
        }
    }
}
