using Blog.Controllers;
using NUnit.Framework;

namespace Blog.Tests.Controllers
{
    [TestFixture]
    public class ErrorControllerTests : ControllerTextFixture
    {
        private ErrorController errorController;

        [SetUp]
        public void SetUp()
        {
            errorController = new ErrorController();
        }

        [Test]
        public void Error_ShouldUseErrorView_Always()
        {
            var result = Test(errorController.Error());

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }

        [Test]
        public void Error404_ShouldUseError404View_Always()
        {
            var result = Test(errorController.Error404());

            Assert.That(result.ViewName, Is.EqualTo("Error404"));
        }
    }
}
