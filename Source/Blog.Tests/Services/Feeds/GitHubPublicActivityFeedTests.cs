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
    public class GitHubPublicActivityFeedTests
    {
        private IEventFeed gitHubPublicActivityFeed;
        private Mock<ISyndicationService> mockSyndicationService;
        private SyndicateItemEntityFactory syndicateItemEntityFactory;

        [SetUp]
        public void SetUp()
        {
            syndicateItemEntityFactory = new SyndicateItemEntityFactory();
            mockSyndicationService = new Mock<ISyndicationService>();
            gitHubPublicActivityFeed = new GitHubPublicActivityFeed(mockSyndicationService.Object);
        }

        [Test]
        public void All_ShouldReturnAllPublicActivity_Always()
        {
            mockSyndicationService.Setup(service => service.Load("gitHubUri")).Returns(CreateSyndicationItems());

            var aggregates = gitHubPublicActivityFeed.All();

            Assert.That(aggregates[0].Source, Is.EqualTo("Git Hub Public Activity"));
            Assert.That(aggregates[0].Title, Is.EqualTo("henrylawson starred ajaxorg/cloud9"));
            Assert.That(aggregates[0].Date, Is.EqualTo(new DateTime(2012, 2, 1)));
            Assert.That(aggregates[0].Link, Is.EqualTo("https://github.com/ajaxorg/cloud9"));
            Assert.That(aggregates[1].Source, Is.EqualTo("Git Hub Public Activity"));
            Assert.That(aggregates[1].Title, Is.EqualTo("henrylawson pushed to master at henrylawson/HenryLawsonBlog"));
            Assert.That(aggregates[1].Date, Is.EqualTo(new DateTime(2012, 10, 1)));
            Assert.That(aggregates[1].Link, Is.EqualTo("https://github.com/henrylawson/HenryLawsonBlog/compare/24c31c2e67...0e3e1540af"));
            mockSyndicationService.VerifyAll();
        }

        private SyndicationItem[] CreateSyndicationItems()
        {
            return new[] 
            { 
                syndicateItemEntityFactory.CreateSyndicationItem("henrylawson starred ajaxorg/cloud9", new DateTime(2012, 2, 1), "https://github.com/ajaxorg/cloud9"),
                syndicateItemEntityFactory.CreateSyndicationItem("henrylawson pushed to master at henrylawson/HenryLawsonBlog", new DateTime(2012, 10, 1), "https://github.com/henrylawson/HenryLawsonBlog/compare/24c31c2e67...0e3e1540af")
            };
        }

        
    }
}
