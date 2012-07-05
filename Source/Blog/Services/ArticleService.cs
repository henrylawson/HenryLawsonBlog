using System.Collections.Generic;
using System.Linq;
using Blog.Models;

namespace Blog.Services
{
    public class ArticleService
    {
        private readonly Dictionary<string, Article> dictionary;

        public ArticleService(IEnumerable<Article> articles)
        {
            dictionary = new Dictionary<string, Article>();
            foreach (var article in articles)
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
            return dictionary.Values.OrderByDescending(article => article.Date).ToList();
        }
    }
}