using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Services;
using NUnit.Framework;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class ArticleServiceTest
    {
        private const string Title = "The Magic Title";
        private ArticleService articleService;
        private IList<Article> articles;

        [SetUp]
        public void SetUp()
        {
            articles = new []
            {
                new Article { Title = Title, Date = new DateTime(2010, 12, 1) },
                new Article { Title = "A Title", Date = new DateTime(2012, 12, 1) }
            };
            articleService = new ArticleService(articles);
        }

        [Test]
        public void Retrieve_CorrectArticle_GivenTheSlugTitle()
        {
            var article = articleService.Retrieve(Title);

            Assert.That(article.SlugTitle, Is.EqualTo(Title));
        }

        [Test]
        public void Retrieve_Null_GivenARandomNonExisitingSlugTitle()
        {
            Assert.Throws<KeyNotFoundException>(() => articleService.Retrieve("random slug title that doesn't exist"));
        }

        [Test]
        public void All_ListOfArticles_WhenTheyExist()
        {
            var serviceArticles = articleService.All();

            Assert.That(articles.Count, Is.EqualTo(serviceArticles.Count));
            Assert.True(serviceArticles.All(articles.Contains));
        }

        [Test]
        public void All_ListOfArticles_SortedByDate()
        {
            var serviceArticles = articleService.All();

            Assert.That(serviceArticles[0], Is.EqualTo(articles[1]));
            Assert.That(serviceArticles[1], Is.EqualTo(articles[0]));
        }
    }
}
