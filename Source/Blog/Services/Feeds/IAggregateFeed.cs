using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services.Feeds
{
    public interface IAggregateFeed
    {
        IList<Aggregate> All();
    }
}