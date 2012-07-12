using System.Collections.Generic;
using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class ArticleServiceTest
    {
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
            var articles = CreateArticles();
            mockArticleRepository.Setup(repository => repository.All()).Returns(articles);

            var multipleArticlePresenter = articleService.Home();

            Assert.That(multipleArticlePresenter.Articles[0].SlugTitle, Is.EqualTo(articles[0].SlugTitle));
            Assert.That(multipleArticlePresenter.Articles[1].SlugTitle, Is.EqualTo(articles[1].SlugTitle));
            Assert.That(multipleArticlePresenter.Articles[2].SlugTitle, Is.EqualTo(articles[2].SlugTitle));
            Assert.That(multipleArticlePresenter.ArticleIndexes[0].SlugTitle, Is.EqualTo(articles[3].SlugTitle));
            Assert.That(multipleArticlePresenter.ArticleIndexes[1].SlugTitle, Is.EqualTo(articles[4].SlugTitle));
        }

        [Test]
        public void Article_ShouldRetrieveAndReturnArticle_WhenProvidedThelugTitle()
        {
            var article = CreateArticle();
            mockArticleRepository.Setup(repository => repository.Retrieve(article.SlugTitle)).Returns(article);

            var articlePresenter = articleService.Article(article.SlugTitle);

            Assert.That(articlePresenter.SlugTitle, Is.EqualTo(article.SlugTitle));
        }

        [Test]
        public void Index_ShouldRetrieveAndReturnMappedArticleIndexPresenters_WhenProvided()
        {
            var articles = CreateArticles();
            mockArticleRepository.Setup(repository => repository.All()).Returns(articles);

            var articleIndexes = articleService.Index();

            Assert.That(articleIndexes[0].SlugTitle, Is.EqualTo(articles[0].SlugTitle));
            Assert.That(articleIndexes[1].SlugTitle, Is.EqualTo(articles[1].SlugTitle));
            Assert.That(articleIndexes[2].SlugTitle, Is.EqualTo(articles[2].SlugTitle));
            Assert.That(articleIndexes[3].SlugTitle, Is.EqualTo(articles[3].SlugTitle));
            Assert.That(articleIndexes[4].SlugTitle, Is.EqualTo(articles[4].SlugTitle));
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
            return new Article {Title = title};
        }
    }
}