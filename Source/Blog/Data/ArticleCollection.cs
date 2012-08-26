using System;
using System.Collections.Generic;
using System.IO;
using Blog.Models;

namespace Blog.Data
{
    public class ArticleCollection : IArticleCollection
    {
        private const string DataBodyFilePath = "~/Data/Body/";
        private Func<string, string> resolveBodyPath = HttpResolveFilePath;

        public Func<string, string> ResolveBodyPath
        {
            set
            {
                resolveBodyPath = value; 
            }
        }

        public IList<Article> Entries
        {
            get
            {
                return new[]
                {
                    new Article 
                        {
                            Title = "The Magic Number", 
                            Date = new DateTime(2012, 6, 1),
                            BodyFile = resolveBodyPath.Invoke(@"TheMagicNumber.html")
                        },
                    new Article
                        {
                            Title = "Counting Points at Dev Done",
                            Date = new DateTime(2012, 6, 4), 
                            BodyFile = resolveBodyPath.Invoke(@"CountingPointsAtDevDone.html")
                        }
                };
            }
        }

        private static string HttpResolveFilePath(string file)
        {
            return Path.Combine(System.Web.HttpContext.Current.Server.MapPath(DataBodyFilePath), file);
        }
    }
}