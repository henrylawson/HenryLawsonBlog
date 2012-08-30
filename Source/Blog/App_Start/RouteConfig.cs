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
                name: "Error404",
                url: "Error/404",
                defaults: new { controller = "Error", action = "Error404" });

            routes.MapRoute(
                name: "Error",
                url: "Error",
                defaults: new { controller = "Error", action = "Error" });

            routes.MapRoute(
                name: "Index",
                url: "index",
                defaults: new { controller = "Article", action = "Index" });

            routes.MapRoute(
                name: "Atom",
                url: "atom",
                defaults: new { controller = "Article", action = "Atom" });

            routes.MapRoute(
                name: "Default",
                url: string.Empty,
                defaults: new { controller = "Article", action = "Home" });

            routes.MapRoute(
                name: "Article",
                url: "{slugTitle}",
                defaults: new { controller = "Article", action = "Single", slugTitle = UrlParameter.Optional });
        }
    }
}