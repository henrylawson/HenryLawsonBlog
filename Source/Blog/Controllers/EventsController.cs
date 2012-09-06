using System.Collections.Generic;
using System.Web.Http;
using Blog.Models;
using Blog.Services;

namespace Blog.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IEventAggregateService eventAggregateService;

        public EventsController(IEventAggregateService eventAggregateService)
        {
            this.eventAggregateService = eventAggregateService;
        }

        public IEnumerable<Event> Get()
        {
            return eventAggregateService.All();
        }
    }
}
