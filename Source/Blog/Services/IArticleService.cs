using Blog.Presenters;

namespace Blog.Services
{
    public interface IArticleService
    {
        MultipleArticlePresenter Home();
    }
}