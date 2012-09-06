using System.Collections.Generic;
using Blog.Models;
using Blog.Services;
using Blog.Services.Feeds;
using Blog.Tests.Factories;
using Moq;
using NUnit.Framework;
using StructureMap;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class EventAggregateServiceTests
    {
        private IEventAggregateService eventAggregateService;
        private Mock<IEventFeed> mockAggregateFeed1;
        private Mock<IEventFeed> mockAggregateFeed2;
        private EventEntityFactory eventEntityFactory;

        [SetUp]
        public void SetUp()
        {
            eventEntityFactory = new EventEntityFactory();
            mockAggregateFeed1 = new Mock<IEventFeed>();
            mockAggregateFeed2 = new Mock<IEventFeed>();
            ObjectFactory.Initialize(x =>
                {
                    x.Register(mockAggregateFeed1.Object);
                    x.Register(mockAggregateFeed2.Object);
                });
            eventAggregateService = new EventAggregateService();
        }

        [Test]
        public void All_ShouldReturnDataFromAggregateFeedsOrederedByDateDesc_Always()
        {
            mockAggregateFeed1.Setup(feed => feed.All()).Returns(eventEntityFactory.CreateAggregates());
            mockAggregateFeed2.Setup(feed => feed.All()).Returns(eventEntityFactory.CreateAggregates());

            var aggregates = eventAggregateService.All();

            AssertThatDatesAreDescending(aggregates);
            mockAggregateFeed1.VerifyAll();
            mockAggregateFeed2.VerifyAll();
        }

        private static void AssertThatDatesAreDescending(IList<Event> aggregates)
        {
            for (var i = 1; i < aggregates.Count; i++)
            {
                Assert.That(aggregates[i - 1].Date, Is.GreaterThanOrEqualTo(aggregates[i].Date));
            }
        }
    }
}