using System.Collections.Generic;
using Blog.Presenters;

namespace Blog.Services
{
    public interface IArticleService
    {
        MultipleArticlePresenter Home();
        MultipleArticlePresenter Article(string slugTitle);
        MultipleArticleIndexPresenter Index();
    }
}