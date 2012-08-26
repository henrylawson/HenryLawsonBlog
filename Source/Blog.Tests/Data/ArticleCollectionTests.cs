using System.IO;
using System.Linq;
using Blog.Data;
using NUnit.Framework;

namespace Blog.Tests.Data
{
    [TestFixture]
    public class ArticleCollectionTests
    {
        private ArticleCollection articleCollection;

        [SetUp]
        public void SetUp()
        {
            articleCollection = new ArticleCollection
            {
                ResolveBodyPath = file => Path.Combine(Directory.GetCurrentDirectory(), @"Data\Body", file)
            };
        }

        [Test]
        public void Entries_ShouldNotBeEmpty_Always()
        {
            Assert.That(articleCollection.Entries, Is.Not.Empty);
        }

        [Test]
        public void Entries_ShouldAllHaveABody_Always()
        {
            Assert.That(articleCollection.Entries.Any(article => string.IsNullOrEmpty(article.Body)), Is.False);
        }
    }
}