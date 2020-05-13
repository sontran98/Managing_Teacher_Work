using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Managing_Teacher_Work
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "Quan ly cong viec",
             url: "quanlycongviec",
             defaults: new { controller = "Work", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "Managing_Teacher_Work.Controllers" }
         );
            routes.MapRoute(
              name: "Quan ly menu",
              url: "quanlymenu",
              defaults: new { controller = "Menu", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "Managing_Teacher_Work.Controllers" }
          );
            routes.MapRoute(
                name: "Quan ly khoa ",
                url: "quanlykhoa",
                defaults: new { controller = "Sciense", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Managing_Teacher_Work.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] {"Managing_Teacher_Work.Controllers"}
            );
        }
    }
}
