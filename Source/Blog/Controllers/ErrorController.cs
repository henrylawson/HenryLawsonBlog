using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            return View("Error");
        }

        public ActionResult Error404()
        {
            return View("Error404");
        }
    }
}
