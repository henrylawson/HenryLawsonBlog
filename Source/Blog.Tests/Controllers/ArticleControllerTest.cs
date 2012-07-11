using System.Collections.Generic;
using System.Web.Mvc;
using Blog.Controllers;
using Blog.Models;
using Blog.Presenters;
using Blog.Repositories;
using Blog.Services;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Controllers
{
    [TestFixture]
    public class ArticleControllerTest
    {
        private ArticleController articleController;
        private Mock<IArticleService> mockArticleService;
        private MultipleArticlePresenter multipleArticlePresenter;

        [SetUp]
        public void SetUp()
        {
            multipleArticlePresenter = new MultipleArticlePresenter();
            mockArticleService = new Mock<IArticleService>();
            mockArticleService.Setup(service => service.Home()).Returns(multipleArticlePresenter);
            articleController = new ArticleController(mockArticleService.Object);
        }

        [Test]
        public void Index_UseIndexView_Always()
        {
            var result = Test(articleController.Home());

            Assert.That(result.ViewName, Is.EqualTo("Home"));
        }

        [Test]
        public void Index_UseArticleServiceTop_Always()
        {
            var result = Test(articleController.Home());

            Assert.That(result.Model, Is.SameAs(multipleArticlePresenter));
        }

        private static ViewResult Test(ActionResult result)
        {
            return result as ViewResult;
        }
    }
}
