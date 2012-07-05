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
            var article = new Article();

            Assert.That(article.SlugTitle, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FormattedDate_FormattedData_WhenDateIsSet()
        {
            var article = new Article {Date = new DateTime(2012, 12, 07)};

            Assert.That(article.FormattedDate, Is.EqualTo("7 Dec, 2012"));
        }
    }
}
