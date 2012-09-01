using System;
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
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            StructureMapSetup.InitializeContainer();
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