using System.Collections.Generic;
using System.Text;
using Blog.Controllers;
using Blog.Presenters;
using Blog.Services;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Controllers
{
    [TestFixture]
    public class ArticleControllerTests : ControllerTextFixture
    {
        private ArticleController articleController;
        private Mock<IArticleService> mockArticleService;
        private Mock<IArticleAtomService> mockArticleAtomService;

        [SetUp]
        public void SetUp()
        {
            mockArticleService = new Mock<IArticleService>();
            mockArticleAtomService = new Mock<IArticleAtomService>();
            articleController = new ArticleController(mockArticleService.Object, mockArticleAtomService.Object);
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
        public void Home_ShouldSetViewBagTitle_Always()
        {
            var result = Test(articleController.Home());

            Assert.That(result.ViewBag.Title, Is.EqualTo("Home"));
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
        public void Single_ShouldSetViewBagTitle_Always()
        {
            var multipleArticlePresenter = CreateMultipleArticlePresenter();
            mockArticleService.Setup(service => service.Article(It.IsAny<string>())).Returns(multipleArticlePresenter);

            var result = Test(articleController.Single("slug-title"));

            Assert.That(result.ViewBag.Title, Is.EqualTo(multipleArticlePresenter.Articles[0].Title));
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

        [Test]
        public void Index_ShouldSetViewBagTitle_Always()
        {
            var result = Test(articleController.Index());

            Assert.That(result.ViewBag.Title, Is.EqualTo("Index"));
        }

        [Test]
        public void Atom_ShouldProvideFeedResult_Always()
        {
            const string feedResult = "some string";
            mockArticleAtomService.Setup(service => service.Feed()).Returns(feedResult);

            var actionResult = TestAsContent(articleController.Atom());

            Assert.That(actionResult.Content, Is.EqualTo(feedResult));
            Assert.That(actionResult.ContentType, Is.EqualTo("text/xml"));
            Assert.That(actionResult.ContentEncoding, Is.EqualTo(Encoding.Unicode));
        }

        [Test]
        public void Single_ShouldRedirectTo404_WhenItDoesNotExist()
        {
            mockArticleService.Setup(service => service.Article(It.IsAny<string>())).Throws<KeyNotFoundException>();

            var viewResult = TestRedirectToRoute(articleController.Single("An article"));

            Assert.That(viewResult.RouteValues["Controller"], Is.EqualTo("Error"));
            Assert.That(viewResult.RouteValues["Action"], Is.EqualTo("Error404"));
        }

        private static MultipleArticleIndexPresenter CreateMultipleArticleIndexPresenters()
        {
            return new MultipleArticleIndexPresenter();
        }

        private static MultipleArticlePresenter CreateMultipleArticlePresenter()
        {
            return new MultipleArticlePresenter
            {
                Articles = new[]
                {
                    new ArticlePresenter
                    {
                        Title = "A title"
                    } 
                }
            };
        }
    }
}
