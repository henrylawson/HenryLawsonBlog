using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Blog.Repositories;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Repositories
{
    [TestFixture]
    public class ArticleServiceTest
    {
        private const string Title = "The Magic Title";
        private ArticleRepository articleService;
        private IList<Article> articles;

        [SetUp]
        public void SetUp()
        {
            articles = new[]
                {
                    new Article {Title = Title, Date = new DateTime(2010, 12, 1)},
                    new Article {Title = "A Title", Date = new DateTime(2012, 12, 1)}
                };
            var articleCollection = new Mock<IArticleCollection>();
            articleCollection.Setup(collection => collection.Entries).Returns(articles);
            articleService = new ArticleRepository(articleCollection.Object);
        }

        [Test]
        public void Retrieve_ShouldReturnCorrectArticle_WhenGivenTheSlugTitle()
        {
            var article = articleService.Retrieve(articles[0].SlugTitle);

            Assert.That(article.Title, Is.EqualTo(Title));
        }

        [Test]
        public void Retrieve_ShouldReturnNull_GivenARandomNonExisitingSlugTitle()
        {
            Assert.Throws<KeyNotFoundException>(() => articleService.Retrieve("random slug title that doesn't exist"));
        }

        [Test]
        public void All_ShouldReturnAllArticles_WhenTheyExist()
        {
            var serviceArticles = articleService.All();

            Assert.That(articles.Count, Is.EqualTo(serviceArticles.Count));
            Assert.True(serviceArticles.All(articles.Contains));
        }

        [Test]
        public void All_ShouldReturnAllArticles_SortedByDate()
        {
            var serviceArticles = articleService.All();

            Assert.That(serviceArticles[0], Is.EqualTo(articles[1]));
            Assert.That(serviceArticles[1], Is.EqualTo(articles[0]));
        }
    }
}
