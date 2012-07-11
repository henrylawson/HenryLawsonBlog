using System.Collections.Generic;
using Blog.Models;

namespace Blog.Repositories
{
    public interface IArticleRepository
    {
        Article Retrieve(string slugTitle);
        IList<Article> All();
    }
}