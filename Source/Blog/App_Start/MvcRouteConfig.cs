using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.App_Start
{
    public class MvcRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Error404", "Error/404", new { controller = "Error", action = "Error404" });
            routes.MapRoute("Error", "Error", new { controller = "Error", action = "Error" });
            routes.MapRoute("Index", "index", new { controller = "Article", action = "Index" });
            routes.MapRoute("Atom", "atom", new { controller = "Article", action = "Atom" });
            routes.MapRoute("Default", string.Empty, new { controller = "Article", action = "Home" });
            routes.MapRoute("Article", "{slugTitle}", new { controller = "Article", action = "Single", slugTitle = UrlParameter.Optional });
        }
    }
}