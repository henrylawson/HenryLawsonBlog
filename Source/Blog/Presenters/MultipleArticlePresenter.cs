using System.Collections.Generic;

namespace Blog.Presenters
{
    public class MultipleArticlePresenter
    {
        public IList<ArticlePresenter> Articles { get; set; }

        public IList<ArticleIndexPresenter> ArticleIndexes { get; set; } 
    }
}