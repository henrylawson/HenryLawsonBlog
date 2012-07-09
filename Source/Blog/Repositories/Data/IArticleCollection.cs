using System.Collections.Generic;
using Blog.Models;

namespace Blog.Repositories.Data
{
    public interface IArticleCollection
    {
        IList<Article> Entries { get; }
    }
}