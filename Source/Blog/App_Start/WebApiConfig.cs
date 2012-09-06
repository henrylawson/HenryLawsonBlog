using System.Web.Http;
using System.Web.Routing;

namespace Blog.App_Start
{
    public class WebApiConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute("Aggregate", "api/aggregate", new { controller = "Aggregate" });
        } 
    }
}