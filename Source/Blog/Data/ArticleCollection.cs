using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Data
{
    public class ArticleCollection : IArticleCollection
    {
        public IList<Article> Entries
        {
            get
            {
                return new[]
                    {
                        new Article {Title = "The Newest Article", Body = "<p>Some content</p>", Date = new DateTime(2012, 9, 9)},
                        new Article {Title = "The First Article", Body = "<p>Some content</p>"},
                        new Article {Title = "The Second", Body = "<p>Some content</p>"},
                        new Article {Title = "The Third", Body = "<p>Some content</p>"},
                        new Article {Title = "The Fourth", Body = "<p>Some content</p>"},
                        new Article {Title = "The Fifth", Body = "<p>Some content</p>"}
                    };
            }
        }
    }
}