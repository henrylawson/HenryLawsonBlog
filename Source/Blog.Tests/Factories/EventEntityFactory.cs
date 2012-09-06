using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Tests.Factories
{
    public class EventEntityFactory
    {
        public IList<Event> CreateAggregates()
        {
            return new[]
                {
                    CreateAggregate(),
                    CreateAggregate(),
                    CreateAggregate()
                };
        }

        public Event CreateAggregate()
        {
            return new Event
                {
                    Date = DateTime.Now
                };
        } 
    }
}