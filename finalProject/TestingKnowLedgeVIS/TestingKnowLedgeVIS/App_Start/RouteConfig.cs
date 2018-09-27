using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestingKnowLedgeVIS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "UserEdit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "EditUser", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "UserDelete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "DeleteUser", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Role",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Role", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RoleEdit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Role", action = "EditRole", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RoleDelete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Role", action = "DeleteRole", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new {Controller = "Account" , Action = "LogIn",id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { Controller = "Account", Action = "Register", id = UrlParameter.Optional }
                );

        }
    }
}
