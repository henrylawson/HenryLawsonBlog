using System.Collections.Generic;
using Blog.Models;

namespace Blog.Data
{
    public interface IArticleCollection
    {
        IList<Article> Entries { get; }
    }
}