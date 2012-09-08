using Blog.Configuration;
using Blog.Services;
using Moq;
using NUnit.Framework;
using StructureMap;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class SyndicationServiceTests
    {
        private ISyndicationService syndicationService;

        [SetUp]
        public void SetUp()
        {
            syndicationService = new SyndicationService();
        }

        [Test]
        public void Load_ShouldReturnSyndicateitems_WhenGivenAConfigKey()
        {
            const string settingKey = "key";
            const string resourceUri = "Resources/sample.atom";
            MockConfigProvider(settingKey, resourceUri);

            var syndicationItems = syndicationService.Load(settingKey);

            Assert.That(syndicationItems[0].Title.Text, Is.EqualTo("henrylawson starred ajaxorg/cloud9"));
            Assert.That(syndicationItems[1].Title.Text, Is.EqualTo("henrylawson pushed to master at henrylawson/HenryLawsonBlog"));
        }

        private static void MockConfigProvider(string settingKey, string uri)
        {
            var mockConfigProvider = new Mock<IConfigProvider>();
            mockConfigProvider.Setup(provider => provider.Setting(settingKey)).Returns(uri);
            ObjectFactory.Inject(mockConfigProvider.Object);
        }
    }
}
