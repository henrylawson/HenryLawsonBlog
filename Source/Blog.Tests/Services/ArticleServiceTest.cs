using System.Linq;
using Blog.Repositories;
using Blog.Services;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class ArticleServiceTest
    {
        private readonly ArticleEntityFactory articleEntityFactory = new ArticleEntityFactory();
        private Mock<IArticleRepository> mockArticleRepository;
        private IArticleService articleService;

        [SetUp]
        public void SetUp()
        {
            mockArticleRepository = new Mock<IArticleRepository>();
            articleService = new ArticleService(mockArticleRepository.Object);
        }

        [Test]
        public void Home_ShouldRetrieveAndMappedMultipleArticlePresenter_WhenProvided()
        {
            var articles = articleEntityFactory.CreateArticles();
            mockArticleRepository.Setup(repository => repository.All()).Returns(articles);

            var multipleArticlePresenter = articleService.Home();

            Assert.That(multipleArticlePresenter.Articles[0].SlugTitle, Is.EqualTo(articles[0].SlugTitle));
            Assert.That(multipleArticlePresenter.Articles[1].SlugTitle, Is.EqualTo(articles[1].SlugTitle));
            Assert.That(multipleArticlePresenter.Index.Title, Is.EqualTo("Other Articles"));
            Assert.That(multipleArticlePresenter.Index.Articles[0].SlugTitle, Is.EqualTo(articles[2].SlugTitle));
            Assert.That(multipleArticlePresenter.Index.Articles[1].SlugTitle, Is.EqualTo(articles[3].SlugTitle));
            Assert.That(multipleArticlePresenter.Index.Articles[2].SlugTitle, Is.EqualTo(articles[4].SlugTitle));
        }

        [Test]
        public void Article_ShouldRetrieveAndReturnArticle_WhenProvidedThelugTitle()
        {
            var article = articleEntityFactory.CreateArticle();
            var indexes = articleEntityFactory.CreateArticles();
            mockArticleRepository.Setup(repository => repository.Retrieve(article.SlugTitle)).Returns(article);
            mockArticleRepository.Setup(repository => repository.AllWhereNot(article.SlugTitle)).Returns(indexes);

            var articlePresenter = articleService.Article(article.SlugTitle);

            Assert.That(articlePresenter.Articles.Count, Is.EqualTo(1));
            Assert.That(articlePresenter.Articles[0].SlugTitle, Is.EqualTo(article.SlugTitle));
            Assert.That(articlePresenter.Index.Articles.All(articleIndexPresenter => indexes.Any(index => index.SlugTitle == articleIndexPresenter.SlugTitle)));
        }

        [Test]
        public void Index_ShouldRetrieveAndReturnMappedArticleIndexPresenters_WhenProvided()
        {
            var articles = articleEntityFactory.CreateArticles();
            mockArticleRepository.Setup(repository => repository.All()).Returns(articles);

            var articleIndexes = articleService.Index();

            Assert.That(articleIndexes.Articles[0].SlugTitle, Is.EqualTo(articles[0].SlugTitle));
            Assert.That(articleIndexes.Articles[1].SlugTitle, Is.EqualTo(articles[1].SlugTitle));
            Assert.That(articleIndexes.Articles[2].SlugTitle, Is.EqualTo(articles[2].SlugTitle));
            Assert.That(articleIndexes.Articles[3].SlugTitle, Is.EqualTo(articles[3].SlugTitle));
            Assert.That(articleIndexes.Articles[4].SlugTitle, Is.EqualTo(articles[4].SlugTitle));
        }
    }
}