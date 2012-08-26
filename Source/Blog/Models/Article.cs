using System;
using System.IO;

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

        public string Body
        {
            get { return File.ReadAllText(BodyFile); }
        }

        public string BodyFile { get; set; }
    }
}