using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services
{
    public interface IAggregateService
    {
        IList<Aggregate> All();
    }
}