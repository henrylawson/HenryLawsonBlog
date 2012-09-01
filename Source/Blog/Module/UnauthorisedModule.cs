using System;
using System.Web;

namespace Blog.Module
{
    public class UnauthorisedModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += OnEndRequest;
        }

        public void Dispose()
        {
        }

        private static void OnEndRequest(object sender, EventArgs eventArgs)
        {
            if (sender == null)
            {
                return;
            }

            var context = ((HttpApplication)sender).Context;
            if (context.Response.StatusCode == 401)
            {
                context.Response.RedirectToRoute("Error404");
            }
        }
    }
}