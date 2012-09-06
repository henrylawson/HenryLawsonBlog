using System;

namespace Blog.Models
{
    public class Event
    {
        public DateTime Date { get; set; }

        public string Source { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }
    }
}