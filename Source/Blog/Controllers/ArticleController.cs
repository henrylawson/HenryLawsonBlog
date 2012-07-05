using System.Linq;
using System.Web.Mvc;
using Blog.Services;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleService articleService;

        public ArticleController(ArticleService articleService)
        {
            this.articleService = articleService;
        }

        public ActionResult Index()
        {
            return View("Index", articleService.All().First());
        }
    }
}