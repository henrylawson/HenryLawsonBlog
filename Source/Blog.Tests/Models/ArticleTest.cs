using System;
using System.IO;
using Blog.Models;
using NUnit.Framework;

namespace Blog.Tests.Models
{
    [TestFixture]
    public class ArticleTest
    {
        private const string Body = "Some string contents";
        private string temporaryFile;

        [SetUp]
        public void SetUp()
        {
            temporaryFile = Path.GetTempFileName();
            File.WriteAllText(temporaryFile, Body);
        }

        [Test]
        public void SlugTitle_ShouldSlugifyTitle_WhenTitleSet()
        {
            var article = new Article { Title = "A New Article Title" };

            Assert.That(article.SlugTitle, Is.EqualTo("a-new-article-title"));
        }

        [Test]
        public void SlugTitle_ShouldSlugifyTitle_WhenTitleNotSet()
        {
            var article = CreateArticle();
            article.Title = string.Empty;

            Assert.That(article.SlugTitle, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Body_ShouldContainBodyFileContents_WhenBodyFileProvided()
        {
            var article = CreateArticle();

            Assert.That(article.Body, Is.EqualTo(Body));
        }
        
        [TearDown]
        public void TearDown()
        {
            File.Delete(temporaryFile);
        }

        private Article CreateArticle()
        {
            return new Article
                {
                    Title = "Some title",
                    Date = new DateTime(),
                    BodyFile = temporaryFile
                };
        }
    }
}
