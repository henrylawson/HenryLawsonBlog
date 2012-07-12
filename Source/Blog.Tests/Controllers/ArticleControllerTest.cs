using System.Collections.Generic;
using System.Web.Mvc;
using Blog.Controllers;
using Blog.Presenters;
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

        [SetUp]
        public void SetUp()
        {
            mockArticleService = new Mock<IArticleService>();
            articleController = new ArticleController(mockArticleService.Object);
        }

        [Test]
        public void Home_ShouldUseHomeView_Always()
        {
            mockArticleService.Setup(service => service.Home()).Returns(CreateMultipleArticlePresenter());

            var result = Test(articleController.Home());

            Assert.That(result.ViewName, Is.EqualTo("Multiple"));
        }

        [Test]
        public void Home_ShouldUseArticleServiceHome_Always()
        {
            var multipleArticlePresenter = CreateMultipleArticlePresenter();
            mockArticleService.Setup(service => service.Home()).Returns(multipleArticlePresenter);

            var result = Test(articleController.Home());

            Assert.That(result.Model, Is.SameAs(multipleArticlePresenter));
        }

        [Test]
        public void Single_ShouldUseArticleView_Always()
        {
            mockArticleService.Setup(service => service.Article(It.IsAny<string>())).Returns(CreateMultipleArticlePresenter());

            var result = Test(articleController.Single("slug-title"));

            Assert.That(result.ViewName, Is.EqualTo("Multiple"));
        }

        [Test]
        public void Single_ShouldUseArticleServiceRetrieve_Always()
        {
            var articlePresenter = CreateMultipleArticlePresenter();
            mockArticleService.Setup(service => service.Article(It.IsAny<string>())).Returns(articlePresenter);

            var result = Test(articleController.Single("slug-title"));

            Assert.That(result.Model, Is.SameAs(articlePresenter));
        }

        [Test]
        public void Index_ShouldUseIndexView_Always()
        {
            mockArticleService.Setup(service => service.Article(It.IsAny<string>())).Returns(CreateMultipleArticlePresenter());

            var result = Test(articleController.Index());

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void Index_ShouldUseArticleServiceIndex_Always()
        {
            var articleIndexPresenters = CreateMultipleArticleIndexPresenters();
            mockArticleService.Setup(service => service.Index()).Returns(articleIndexPresenters);

            var result = Test(articleController.Index());

            Assert.That(result.Model, Is.SameAs(articleIndexPresenters));
        }

        private static MultipleArticleIndexPresenter CreateMultipleArticleIndexPresenters()
        {
            return new MultipleArticleIndexPresenter();
        }

        private static MultipleArticlePresenter CreateMultipleArticlePresenter()
        {
            return new MultipleArticlePresenter();
        }

        private static ArticlePresenter CreateArticlePresenter()
        {
            return new ArticlePresenter();
        }

        private static ViewResult Test(ActionResult result)
        {
            return result as ViewResult;
        }
    }
}
