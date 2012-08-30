using Blog.Repositories;
using Blog.Services;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class ArticleAtomServiceTest
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
            mockArticleRepository.Setup(repository => repository.All()).Returns(articleEntityFactory.CreateArticles());

            var feed = articleAtomService.Feed();

            Assert.That(feed, Is.StringContaining("Title 1"));
            Assert.That(feed, Is.StringContaining("Title 2"));
            Assert.That(feed, Is.StringContaining("Title 3"));
            Assert.That(feed, Is.StringContaining("Title 4"));
            Assert.That(feed, Is.StringContaining("Title 5"));
            Assert.That(feed, Is.StringContaining("Title 6"));
        }
    }
}