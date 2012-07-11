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
        private ArticleService articleService;
        private IList<Article> articles;

        [SetUp]
        public void SetUp()
        {
            articles = CreateArticles();
            mockArticleRepository = new Mock<IArticleRepository>();
            mockArticleRepository.Setup(repository => repository.All()).Returns(articles);
            articleService = new ArticleService(mockArticleRepository.Object);
        }

        [Test]
        public void Home_RetrieveAndMapArticles_ProvidedByRepository()
        {
            mockArticleRepository.Setup(repository => repository.All()).Returns(articles);

            var multipleArticlePresenter = articleService.Home();

            Assert.That(multipleArticlePresenter.Articles[0].SlugTitle, Is.EqualTo(articles[0].SlugTitle));
            Assert.That(multipleArticlePresenter.Articles[1].SlugTitle, Is.EqualTo(articles[1].SlugTitle));
            Assert.That(multipleArticlePresenter.Articles[2].SlugTitle, Is.EqualTo(articles[2].SlugTitle));
            Assert.That(multipleArticlePresenter.ArticleIndexes[0].SlugTitle, Is.EqualTo(articles[3].SlugTitle));
            Assert.That(multipleArticlePresenter.ArticleIndexes[1].SlugTitle, Is.EqualTo(articles[4].SlugTitle));
        }

        private IList<Article> CreateArticles()
        {
            return new[]
                {
                    new Article {Title = "Title 1"},
                    new Article {Title = "Title 2"},
                    new Article {Title = "Title 3"},
                    new Article {Title = "Title 4"},
                    new Article {Title = "Title 5"},
                    new Article {Title = "Title 6"}
                };
        }
    }
}