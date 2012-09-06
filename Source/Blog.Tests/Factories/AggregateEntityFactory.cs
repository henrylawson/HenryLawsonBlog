using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Tests.Factories
{
    public class AggregateEntityFactory
    {
        public IList<Aggregate> CreateAggregates()
        {
            return new[]
                {
                    CreateAggregate(),
                    CreateAggregate(),
                    CreateAggregate()
                };
        }

        public Aggregate CreateAggregate()
        {
            return new Aggregate
                {
                    Date = DateTime.Now
                };
        } 
    }
}