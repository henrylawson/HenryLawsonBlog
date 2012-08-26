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
                        },
                    new Article
                        {
                            Title = "Estimation Sessions are not for Estimating",
                            Date = new DateTime(2012, 7, 5), 
                            BodyFile = resolveBodyPath.Invoke(@"EstimationSessionsAreNotForEstimating.html")
                        },
                    new Article
                        {
                            Title = "Distributed Technical Debt Walls",
                            Date = new DateTime(2012, 7, 10), 
                            BodyFile = resolveBodyPath.Invoke(@"DistributedTechnicalDebtBoards.html")
                        },
                    new Article
                        {
                            Title = "Closed Retrospective",
                            Date = new DateTime(2012, 7, 12), 
                            BodyFile = resolveBodyPath.Invoke(@"ClosedRetrospectives.html")
                        },
                    new Article
                        {
                            Title = "Counting Points at Dev Done In Hindsight",
                            Date = new DateTime(2012, 7, 14), 
                            BodyFile = resolveBodyPath.Invoke(@"CountingPointsAtDevDoneInHindsight.html")
                        },
                    new Article
                        {
                            Title = "The Big Refactoring Or Optimization",
                            Date = new DateTime(2012, 7, 17), 
                            BodyFile = resolveBodyPath.Invoke(@"TheBigRefactoringOrOptimization.html")
                        },
                    new Article
                        {
                            Title = "Early, Late or Very Late Optimization",
                            Date = new DateTime(2012, 8, 20), 
                            BodyFile = resolveBodyPath.Invoke(@"EarlyLateOrVeryLateOptimization.html")
                        },
                    new Article
                        {
                            Title = "The Service Locator Code Smell",
                            Date = new DateTime(2012, 8, 26), 
                            BodyFile = resolveBodyPath.Invoke(@"ServiceLocatorVsDependencyInjection.html")
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