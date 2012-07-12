using System.Web.Mvc;
using Blog.Services;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public ActionResult Home()
        {
            return View("Home", articleService.Home());
        }

        public ActionResult Single(string slugTitle)
        {
            return View("Single", articleService.Article(slugTitle));
        }

        public ActionResult Index()
        {
            return View("Index", articleService.Index());
        }
    }
}