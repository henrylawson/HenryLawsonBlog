using System.Collections.Generic;
using Blog.Models;

namespace Blog.Repositories.Data
{
    public class ArticleCollection : IArticleCollection
    {
        public IList<Article> Entries
        {
            get
            {
                return new[]
                    {
                        new Article {Title = "asdfafdsa"},
                        new Article {Title = "asdfafdsa asdfasd"},
                        new Article {Title = "asdfafdsa asdf"}
                    };
            }
        }
    }
}