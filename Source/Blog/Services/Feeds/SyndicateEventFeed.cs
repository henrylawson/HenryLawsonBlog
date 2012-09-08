using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using Blog.Models;

namespace Blog.Services.Feeds
{
    public abstract class SyndicateEventFeed : IEventFeed
    {
        private readonly ISyndicationService syndicationService;

        protected SyndicateEventFeed(ISyndicationService syndicationService)
        {
            this.syndicationService = syndicationService;
        }


        public IList<Event> SyndicateItems(string uri)
        {
            return syndicationService.Load(uri).Select(ToEvent).ToList();
        }

        public abstract IList<Event> All();

        protected abstract Event ToEvent(SyndicationItem syndicationItem);
    }
}