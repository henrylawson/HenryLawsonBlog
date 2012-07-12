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
                name: "Index",
                url: "index",
                defaults: new { controller = "Article", action = "Index" }
            );

            routes.MapRoute(
                name: "Atom",
                url: "feed.atom",
                defaults: new { controller = "Article", action = "Atom" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Article", action = "Home" }
            );

            routes.MapRoute(
                name: "Article",
                url: "{slugTitle}",
                defaults: new { controller = "Article", action = "Single", slugTitle = UrlParameter.Optional }
            );
        }
    }
}