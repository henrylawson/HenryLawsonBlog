using Blog.Controllers;
using Blog.Services;
using Blog.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Controllers
{
    [TestFixture]
    public class AggregateControllerTests
    {
        private EventsController eventsController;
        private Mock<IEventAggregateService> mockAggregateService;
        private EventEntityFactory eventEntityFactory;

        [SetUp]
        public void SetUp()
        {
            eventEntityFactory = new EventEntityFactory();
            mockAggregateService = new Mock<IEventAggregateService>();
            eventsController = new EventsController(mockAggregateService.Object);
        }

        [Test]
        public void Get_ShouldReturnAllServiceAggregates_Always()
        {
            var serviceAggregates = eventEntityFactory.CreateAggregates();
            mockAggregateService.Setup(service => service.All()).Returns(serviceAggregates);

            var aggregates = eventsController.Get();

            Assert.That(aggregates, Is.SameAs(serviceAggregates));
        }
    }
}