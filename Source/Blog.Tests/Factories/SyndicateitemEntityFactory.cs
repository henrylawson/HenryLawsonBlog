using System;
using System.ServiceModel.Syndication;

namespace Blog.Tests.Factories
{
    public class SyndicateItemEntityFactory
    {
        public SyndicationItem CreateSyndicationItem(string title, DateTime dateTime, string link)
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
