using System.Collections.Generic;
using System.Web.Http;
using Blog.Models;
using Blog.Services;

namespace Blog.Controllers
{
    public class AggregateController : ApiController
    {
        private readonly IAggregateService aggregateService;

        public AggregateController(IAggregateService aggregateService)
        {
            this.aggregateService = aggregateService;
        }

        public IEnumerable<Aggregate> Get()
        {
            return aggregateService.All();
        }
    }
}
