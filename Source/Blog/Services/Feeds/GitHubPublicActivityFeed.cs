using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using Blog.Models;

namespace Blog.Services.Feeds
{
    public class GitHubPublicActivityFeed : IEventFeed
    {
        private const string GitHubPublicActivity = "Git Hub Public Activity";
        private const string SydnicationUri = "gitHubUri";
        private readonly ISyndicationService syndicationService;

        public GitHubPublicActivityFeed(ISyndicationService syndicationService)
        {
            this.syndicationService = syndicationService;
        }


        public IList<Event> All()
        {
            return syndicationService.Load(SydnicationUri).Select(ToEvent).ToList();
        }

        private static Event ToEvent(SyndicationItem syndicationItem)
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