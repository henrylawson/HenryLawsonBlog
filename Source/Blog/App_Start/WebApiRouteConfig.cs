using System.Web.Http;
using System.Web.Routing;

namespace Blog.App_Start
{
    public class WebApiRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute("Events", "api/events", new { controller = "Events" });
        } 
    }
}