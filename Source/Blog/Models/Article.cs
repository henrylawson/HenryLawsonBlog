using System;

namespace Blog.Models
{
    public class Article
    {
        public string SlugTitle
        {
            get { return string.IsNullOrEmpty(Title) ? string.Empty : Title.Replace(" ", "-").ToLower(); }
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string FormattedDate
        {
            get { return Date.ToString("d MMM, yyyy"); }
        }
    }
}