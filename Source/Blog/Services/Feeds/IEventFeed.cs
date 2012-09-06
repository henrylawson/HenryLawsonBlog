using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services.Feeds
{
    public interface IEventFeed
    {
        IList<Event> All();
    }
}