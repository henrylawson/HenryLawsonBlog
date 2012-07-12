using System.Collections.Generic;
using Blog.Presenters;

namespace Blog.Services
{
    public interface IArticleService
    {
        MultipleArticlePresenter Home();
        ArticlePresenter Article(string slugTitle);
        IList<ArticleIndexPresenter> Index();
    }
}