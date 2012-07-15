using System.Collections.Generic;

namespace Blog.Presenters
{
    public class MultipleArticlePresenter
    {
        private readonly MultipleArticleIndexPresenter index = new MultipleArticleIndexPresenter();

        public IList<ArticlePresenter> Articles { get; set; }

        public MultipleArticleIndexPresenter Index
        {
            get { return index; }
        }
    }
}