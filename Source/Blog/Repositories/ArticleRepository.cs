using System.Collections.Generic;
using System.Linq;
using Blog.Data;
using Blog.Models;

namespace Blog.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly Dictionary<string, Article> dictionary;

        public ArticleRepository(IArticleCollection articleCollection)
        {
            dictionary = new Dictionary<string, Article>();
            foreach (var article in articleCollection.Entries)
            {
                dictionary.Add(article.SlugTitle, article);
            }
        }

        public virtual Article Retrieve(string slugTitle)
        {
            return dictionary[slugTitle];
        }

        public virtual IList<Article> All()
        {
            return OrderedArticles().ToList();
        }

        public IList<Article> AllWhereNot(string slugTitle)
        {
            return OrderedArticles().Where(article => article.SlugTitle != slugTitle).ToList();
        }

        private IEnumerable<Article> OrderedArticles()
        {
            return dictionary.Values.OrderByDescending(article => article.Date);
        }
    }
}