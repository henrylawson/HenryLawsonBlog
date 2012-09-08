using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Blog.Models;

namespace Blog.Services.Feeds
{
    public class GitHubPublicActivityFeed : SyndicateEventFeed
    {
        private const string SydnicationUriKey = "gitHubUri";
        private const string GitHubPublicActivity = "Git Hub Public Activity";

        public GitHubPublicActivityFeed(ISyndicationService syndicationService) 
            : base(syndicationService)
        {
        }

        public override IList<Event> All()
        {
            return SyndicateItems(SydnicationUriKey);
        }

        protected override Event ToEvent(SyndicationItem syndicationItem)
        {
            return new Event
            {
                Title = syndicationItem.Title.Text,
                Link = syndicationItem.Links[0].Uri.ToString(),
                Source = GitHubPublicActivity,
                Date = syndicationItem.PublishDate.Date
            };
        }
    }
}