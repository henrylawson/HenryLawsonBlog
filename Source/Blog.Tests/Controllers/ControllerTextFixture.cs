using System.Web.Mvc;

namespace Blog.Tests.Controllers
{
    public class ControllerTextFixture
    {
        protected static ContentResult TestAsContent(ActionResult actionResult)
        {
            return actionResult as ContentResult;
        }

        protected static ViewResult Test(ActionResult result)
        {
            return result as ViewResult;
        }

        protected static RedirectToRouteResult TestRedirectToRoute(ActionResult actionResult)
        {
            return actionResult as RedirectToRouteResult;
        }
    }
}