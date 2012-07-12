using System.Collections.Generic;

namespace Blog.Presenters
{
    public class MultipleArticleIndexPresenter
    {
        public string Title { get; set; }

        public IList<ArticleIndexPresenter> Articles { get; set; } 
    }
}