using System.Collections.Generic;
using Blog.Controllers;
using Blog.Models;
using Blog.Services;
using Blog.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Controllers
{
    [TestFixture]
    public class AggregateControllerTests
    {
        private AggregateController aggregateController;
        private Mock<IAggregateService> mockAggregateService;
        private AggregateEntityFactory aggregateEntityFactory;

        [SetUp]
        public void SetUp()
        {
            aggregateEntityFactory = new AggregateEntityFactory();
            mockAggregateService = new Mock<IAggregateService>();
            aggregateController = new AggregateController(mockAggregateService.Object);
        }

        [Test]
        public void Get_ShouldReturnAllServiceAggregates_Always()
        {
            var serviceAggregates = aggregateEntityFactory.CreateAggregates();
            mockAggregateService.Setup(service => service.All()).Returns(serviceAggregates);

            var aggregates = aggregateController.Get();

            Assert.That(aggregates, Is.SameAs(serviceAggregates));
        }
    }
}