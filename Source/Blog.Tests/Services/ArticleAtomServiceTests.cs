using System.Linq;
using Blog.Repositories;
using Blog.Services;
using Blog.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class ArticleAtomServiceTests
    {
        private readonly ArticleEntityFactory articleEntityFactory = new ArticleEntityFactory();
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
            var articles = articleEntityFactory.CreateArticles();
            mockArticleRepository.Setup(repository => repository.All()).Returns(articles);

            var feed = articleAtomService.Feed();

            Assert.That(articles.All(article => feed.Contains(article.Title)));
        }
    }
}