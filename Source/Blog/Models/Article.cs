using System;
using System.IO;
using System.Linq;

namespace Blog.Models
{
    public class Article
    {
        private string body;

        public string SlugTitle
        {
            get { return string.IsNullOrEmpty(Title) ? string.Empty : Slugify(StripOtherChars(Title)); }
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Body
        {
            get { return body ?? (body = File.ReadAllText(BodyFile)); }
        }

        public string BodyFile { get; set; }

        private static string Slugify(string title)
        {
            return title.Replace(" ", "-").ToLower();
        }

        private static string StripOtherChars(string title)
        {
            return new string(title.Where(c => char.IsLetterOrDigit(c) || c == ' ').ToArray());
        }
    }
}