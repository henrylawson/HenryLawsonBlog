using System;
using System.ServiceModel.Syndication;
using Blog.Services;
using Blog.Services.Feeds;
using Moq;
using NUnit.Framework;

namespace Blog.Tests.Services.Feeds
{
    [TestFixture]
    public class GitHubPublicActivityFeedTests
    {
        private IEventFeed gitHubPublicActivityFeed;
        private Mock<ISyndicationService> mockSyndicationService;

        [SetUp]
        public void SetUp()
        {
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

        private static SyndicationItem[] CreateSyndicationItems()
        {
            return new[] 
            { 
                CreateSyndicationItem("henrylawson starred ajaxorg/cloud9", new DateTime(2012, 2, 1), "https://github.com/ajaxorg/cloud9"),
                CreateSyndicationItem("henrylawson pushed to master at henrylawson/HenryLawsonBlog", new DateTime(2012, 10, 1), "https://github.com/henrylawson/HenryLawsonBlog/compare/24c31c2e67...0e3e1540af")
            };
        }

        private static SyndicationItem CreateSyndicationItem(string title, DateTime dateTime, string link)
        {
            var syndicationItem = new SyndicationItem
                {
                    Title = new TextSyndicationContent(title),
                    PublishDate = new DateTimeOffset(dateTime),
                };
            syndicationItem.Links.Add(new SyndicationLink(new Uri(link)));
            return syndicationItem;
        }
    }
}
