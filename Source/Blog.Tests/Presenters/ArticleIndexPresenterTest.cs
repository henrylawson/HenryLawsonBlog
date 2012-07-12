using System;
using Blog.Presenters;
using NUnit.Framework;

namespace Blog.Tests.Presenters
{
    [TestFixture]
    public class ArticleIndexPresenterTest
    {
        [Test]
        public void FormattedDate_ShouldFormatDate_WhenDateIsSet()
        {
            var article = new ArticleIndexPresenter
                {
                    Title = "Hello",
                    SlugTitle = "hello",
                    Date = new DateTime(2012, 12, 07)
                };

            Assert.That(article.FormattedDate, Is.EqualTo("7 Dec, 2012"));
        }
    }
}