using System.Collections.Generic;
using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class ArticleAtomServiceTest
    {
        private Mock<IArticleRepository> mockArticleRepository;
        private ArticleAtomService articleAtomService;

        [SetUp]
        public void SetUp()
        {
            mockArticleRepository = new Mock<IArticleRepository>();
            articleAtomService = new ArticleAtomService(mockArticleRepository.Object);
        }

        [Test]
        public void Feed_ShouldProvidedItemsAsSyndicateItems_WhenProvided()
        {
            mockArticleRepository.Setup(repository => repository.All()).Returns(CreateArticles());

            var feed = articleAtomService.Feed();

            Assert.That(feed, Is.StringContaining("Title 1"));
            Assert.That(feed, Is.StringContaining("Title 2"));
            Assert.That(feed, Is.StringContaining("Title 3"));
            Assert.That(feed, Is.StringContaining("Title 4"));
            Assert.That(feed, Is.StringContaining("Title 5"));
            Assert.That(feed, Is.StringContaining("Title 6"));
        }

        private static IList<Article> CreateArticles()
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

        private static Article CreateArticle(string title = "Some Title")
        {
            return new Article { Title = title };
        }
    }
}