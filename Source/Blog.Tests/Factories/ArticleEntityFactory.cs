using System.Collections.Generic;
using Blog.Models;
using Moq;

namespace Blog.Tests.Factories
{
    public class ArticleEntityFactory
    {
        public IList<Article> CreateArticles()
        {
            return new[]
                {
                    CreateArticle("Title 1"),
                    CreateArticle("Title 2"),
                    CreateArticle("Title 3"),
                    CreateArticle("Title 4"),
                    CreateArticle("Title 5"),                    CreateArticle("Title 6")
                };
        }

        public Article CreateArticle(string title = "Some Title")
        {
            var mockArticle = new Mock<Article>();
            mockArticle.Setup(article => article.Title).Returns(title);
            mockArticle.Setup(article => article.Body).Returns("Some body content.");
            return mockArticle.Object;
        }
    }
}