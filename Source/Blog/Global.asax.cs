using System.Web.Mvc;
using System.Web.Routing;
using Blog.Dependencies;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            StructureMapSetup.InitializeContainer();
        }
    }
}