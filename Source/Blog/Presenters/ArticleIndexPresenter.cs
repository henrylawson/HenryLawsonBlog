using System;

namespace Blog.Presenters
{
    public class ArticleIndexPresenter
    {
        public string Title { get; set; }
        
        public string SlugTitle { get; set; }

        public DateTime Date { get; set; }

        public string FormattedDate
        {
            get { return Date.ToString("d MMM, yyyy"); }
        }
    }
}