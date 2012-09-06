using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services
{
    public interface IEventAggregateService
    {
        IList<Event> All();
    }
}