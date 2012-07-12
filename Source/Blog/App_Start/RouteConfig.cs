using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Article",
                url: "article/{slugTitle}",
                defaults: new { controller = "Article", action = "Single", slugTitle = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Index",
                url: "Index",
                defaults: new { controller = "Article", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Article", action = "Home" }
            );
        }
    }
}