using System;
using System.IO;
using System.Linq;

namespace Blog.Models
{
    public class Article
    {
        private string body;

        public virtual string SlugTitle
        {
            get { return string.IsNullOrEmpty(Title) ? string.Empty : Slugify(StripOtherChars(Title)); }
        }

        public virtual DateTime Date { get; set; }

        public virtual string Title { get; set; }

        public virtual string Body
        {
            get { return body ?? (body = File.ReadAllText(BodyFile)); }
        }

        public virtual string BodyFile { get; set; }

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