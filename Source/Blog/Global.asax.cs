using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.App_Start;
using Blog.Dependencies;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            EndRequest += OnEndRequest;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            MvcRouteConfig.RegisterRoutes(RouteTable.Routes);
            WebApiRouteConfig.RegisterRoutes(RouteTable.Routes);
            StructureMapConfig.RegisterDependencies(GlobalConfiguration.Configuration);
        }

        private void OnEndRequest(object sender, EventArgs eventArgs)
        {
            if (Context.Response.StatusCode == 401)
            {
                Context.Response.RedirectToRoute("Error404");
            }
        }
    }
}