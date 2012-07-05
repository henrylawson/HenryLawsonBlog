using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Blog.Controllers;
using Blog.Models;
using Blog.Services;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Controllers
{
    [TestFixture]
    public class ArticleControllerTest
    {
        private ArticleController articleController;
        private Mock<ArticleService> mockArticleService;
        private IList<Article> articles;

        [SetUp]
        public void SetUp()
        {
            articles = CreateArticles();
            mockArticleService = new Mock<ArticleService>(articles);
            mockArticleService.Setup(service => service.All()).Returns(articles);
            articleController = new ArticleController(mockArticleService.Object);
        }

        [Test]
        public void Index_UseIndexView_Always()
        {
            var result = Test(articleController.Index());

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void Index_UseArticleServiceTop_Always()
        {
            var result = Test(articleController.Index());

            Assert.That(result.Model, Is.SameAs(articles[0]));
        }

        private static IList<Article> CreateArticles()
        {
            return new[]
            {
                new Article {Title = "Title 1"},         
                new Article {Title = "Title 2"},         
                new Article {Title = "Title 3"},         
                new Article {Title = "Title 4"}         
            };
        }

        private static ViewResult Test(ActionResult result)
        {
            return result as ViewResult;
        }
    }
}
