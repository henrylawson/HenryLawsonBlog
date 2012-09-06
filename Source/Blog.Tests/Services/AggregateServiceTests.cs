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
    public class AggregateServiceTests
    {
        private IAggregateService aggregateService;
        private Mock<IAggregateFeed> mockAggregateFeed1;
        private Mock<IAggregateFeed> mockAggregateFeed2;
        private AggregateEntityFactory aggregateEntityFactory;

        [SetUp]
        public void SetUp()
        {
            aggregateEntityFactory = new AggregateEntityFactory();
            mockAggregateFeed1 = new Mock<IAggregateFeed>();
            mockAggregateFeed2 = new Mock<IAggregateFeed>();
            ObjectFactory.Initialize(x =>
                {
                    x.Register(mockAggregateFeed1.Object);
                    x.Register(mockAggregateFeed2.Object);
                });
            aggregateService = new AggregateService();
        }

        [Test]
        public void All_ShouldReturnDataFromAggregateFeedsOrederedByDateDesc_Always()
        {
            mockAggregateFeed1.Setup(feed => feed.All()).Returns(aggregateEntityFactory.CreateAggregates());
            mockAggregateFeed2.Setup(feed => feed.All()).Returns(aggregateEntityFactory.CreateAggregates());

            var aggregates = aggregateService.All();

            AssertThatDatesAreDescending(aggregates);
            mockAggregateFeed1.VerifyAll();
            mockAggregateFeed2.VerifyAll();
        }

        private static void AssertThatDatesAreDescending(IList<Aggregate> aggregates)
        {
            for (var i = 1; i < aggregates.Count; i++)
            {
                Assert.That(aggregates[i - 1].Date, Is.GreaterThanOrEqualTo(aggregates[i].Date));
            }
        }
    }
}