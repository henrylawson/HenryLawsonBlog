using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Services.Feeds;
using StructureMap;

namespace Blog.Services
{
    public class AggregateService : IAggregateService
    {
        public IList<Aggregate> All()
        {
            var aggregateFeeds = ObjectFactory.GetAllInstances<IAggregateFeed>();
            var aggregates = aggregateFeeds.SelectMany(feeds => feeds.All());
            return aggregates.OrderByDescending(aggregate => aggregate.Date).ToList();
        }
    }
}