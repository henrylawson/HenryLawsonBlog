using System;

namespace Blog.Models
{
    public class Aggregate
    {
        public DateTime Date { get; set; }

        public string Source { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }
    }
}