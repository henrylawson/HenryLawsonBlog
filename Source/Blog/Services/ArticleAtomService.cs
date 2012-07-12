using System;
using System.Linq;
using System.Text;
using System.Xml;
using Argotic.Syndication;
using Blog.Models;
using Blog.Repositories;
using MvcContrib.TestHelper.Ui;

namespace Blog.Services
{
    public class ArticleAtomService : IArticleAtomService
    {
        private readonly IArticleRepository articleRepository;
        private const int FeedSize = 20;

        public ArticleAtomService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public string Feed()
        {
            var articles = articleRepository.All().Take(FeedSize).ToList();
            var feed = CreateAtomFeed(articles[0].Date);
            var atomEntries = articles.Select(CreateAtomEntry);
            atomEntries.ForEach(entry => feed.AddEntry(entry));
            return ToXmlString(feed);
        }

        private static string ToXmlString(AtomFeed feed)
        {
            var stringBuilder = new StringBuilder();
            var xmlWriter = XmlWriter.Create(stringBuilder);
            feed.Save(xmlWriter);
            xmlWriter.Flush();
            xmlWriter.Close();
            return stringBuilder.ToString();
        }

        private static AtomEntry CreateAtomEntry(Article article)
        {
            var slugUri = string.Format("http://henrylawson.net/{0}", article.SlugTitle);
            var entry = new AtomEntry
                {
                    Id = new AtomId(new Uri(slugUri)),
                    Title = new AtomTextConstruct(article.Title),
                    UpdatedOn = article.Date,
                    PublishedOn = article.Date,
                    Content = new AtomContent(article.Body, "html"),
                };
            entry.Links.Add(new AtomLink
                {
                    Uri = new Uri(slugUri)
                });
            return entry;
        }

        private static AtomFeed CreateAtomFeed(DateTime updatedOn)
        {
            var feed = new AtomFeed
                {
                    Id = new AtomId(new Uri("http://henrylawson.net/feed.atom")),
                    Title = new AtomTextConstruct("Henry Lawson"),
                    UpdatedOn = updatedOn
                };
            feed.Authors.Add(new AtomPersonConstruct("Henry Lawson"));
            feed.Links.Add(new AtomLink
                {
                    Uri = new Uri("http://henrylawson")
                });
            feed.Links.Add(new AtomLink
                {
                    Relation = "self",
                    Uri = new Uri("http://henrylawson/atom")
                });
            return feed;
        }
    }
}