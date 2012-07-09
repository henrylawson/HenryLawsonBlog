using System;

namespace Blog.Presenters
{
    public class ArticleIndexPresenter
    {
        private DateTime date;

        public string Title { get; set; }
        
        public string SlugTitle { get; set; }

        public DateTime Date
        {
            set { date = value; }
        }

        public string FormattedDate
        {
            get { return date.ToString("d MMM, yyyy"); }
        }
    }
}