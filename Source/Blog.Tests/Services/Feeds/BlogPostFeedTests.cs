using System;
using System.ServiceModel.Syndication;
using Blog.Services;
using Blog.Services.Feeds;
using Blog.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Services.Feeds
{
    [TestFixture]
    public class BlogPostFeedTests
    {
        private IEventFeed gitHubPublicActivityFeed;
        private Mock<ISyndicationService> mockSyndicationService;
        private SyndicateItemEntityFactory syndicateItemEntityFactory;

        [SetUp]
        public void SetUp()
        {
            syndicateItemEntityFactory = new SyndicateItemEntityFactory();
            mockSyndicationService = new Mock<ISyndicationService>();
            gitHubPublicActivityFeed = new BlogPostFeed(mockSyndicationService.Object);
        }

        [Test]
        public void All_ShouldReturnAllPublicActivity_Always()
        {
            mockSyndicationService.Setup(service => service.Load("blogPostFeedUri")).Returns(CreateSyndicationItems());

            var aggregates = gitHubPublicActivityFeed.All();

            Assert.That(aggregates[0].Source, Is.EqualTo("Blog Post"));
            Assert.That(aggregates[0].Title, Is.EqualTo("New Article Title"));
            Assert.That(aggregates[0].Date, Is.EqualTo(new DateTime(2012, 2, 1)));
            Assert.That(aggregates[0].Link, Is.EqualTo("http://www.google.com/"));
            Assert.That(aggregates[1].Source, Is.EqualTo("Blog Post"));
            Assert.That(aggregates[1].Title, Is.EqualTo("Other Article Title"));
            Assert.That(aggregates[1].Date, Is.EqualTo(new DateTime(2012, 10, 1)));
            Assert.That(aggregates[1].Link, Is.EqualTo("http://www.google.com/"));
            mockSyndicationService.VerifyAll();
        }

        private SyndicationItem[] CreateSyndicationItems()
        {
            return new[] 
            { 
                syndicateItemEntityFactory.CreateSyndicationItem("New Article Title", new DateTime(2012, 2, 1), "http://www.google.com"),
                syndicateItemEntityFactory.CreateSyndicationItem("Other Article Title", new DateTime(2012, 10, 1), "http://www.google.com")
            };
        }
    }
}
