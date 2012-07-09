using System;
using Blog.Models;
using NUnit.Framework;

namespace Blog.Tests.Models
{
    [TestFixture]
    public class ArticleTest
    {
        [Test]
        public void SlugTitle_SlugifiedTitle_WhenTitleSet()
        {
            var article = new Article {Title = "A New Article Title"};

            Assert.That(article.SlugTitle, Is.EqualTo("a-new-article-title"));
        }

        [Test]
        public void SlugTitle_SlugifiedTitle_WhenTitleNotSet()
        {
            var article = CreateArticle();

            Assert.That(article.SlugTitle, Is.EqualTo(string.Empty));
        }

        private static Article CreateArticle()
        {
            return new Article
                {
                    Title = "Some title",
                    Date = new DateTime(),
                    Body = "Article contents."
                };
        }
    }
}
