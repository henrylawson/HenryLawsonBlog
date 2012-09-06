using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services.Feeds
{
    public class GitHubPublicActivityFeed : IEventFeed
    {
        private const string GitHubPublicActivity = "Git Hub Public Activity";

        public IList<Event> All()
        {
            return new[]
                {
                    new Event
                        {
                            Date = new DateTime(2012, 2, 1),
                            Title = "henrylawson starred ajaxorg/cloud9",
                            Source = GitHubPublicActivity,
                            Link = "https://github.com/ajaxorg/cloud9"
                        }, 
                    new Event
                        {
                            Date = new DateTime(2012, 10, 1),
                            Title = "henrylawson pushed to master at henrylawson/HenryLawsonBlog",
                            Source = GitHubPublicActivity,
                            Link = "https://github.com/henrylawson/HenryLawsonBlog/compare/24c31c2e67...0e3e1540af"
                        }
                };
        }
    }
}