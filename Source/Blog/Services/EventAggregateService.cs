using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Services.Feeds;
using StructureMap;

namespace Blog.Services
{
    public class EventAggregateService : IEventAggregateService
    {
        public IList<Event> All()
        {
            var aggregateFeeds = ObjectFactory.GetAllInstances<IEventFeed>();
            var aggregates = aggregateFeeds.SelectMany(feeds => feeds.All());
            return aggregates.OrderByDescending(aggregate => aggregate.Date).ToList();
        }
    }
}