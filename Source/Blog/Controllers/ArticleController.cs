using System.Text;
using System.Web.Mvc;
using Blog.Services;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IArticleAtomService articleAtomService;

        public ArticleController(IArticleService articleService, IArticleAtomService articleAtomService)
        {
            this.articleService = articleService;
            this.articleAtomService = articleAtomService;
        }

        public ActionResult Home()
        {
            ViewBag.Title = "Home";
            return View("Multiple", articleService.Home());
        }

        public ActionResult Single(string slugTitle)
        {
            var multipleArticlePresenter = articleService.Article(slugTitle);
            ViewBag.Title = multipleArticlePresenter.Articles[0].Title;
            return View("Multiple", multipleArticlePresenter);
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View("Index", articleService.Index());
        }

        public ActionResult Atom()
        {
            return Content(articleAtomService.Feed(), "text/xml", Encoding.Unicode);
        }
    }
}