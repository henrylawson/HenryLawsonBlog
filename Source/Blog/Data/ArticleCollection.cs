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
                            Title = "Counting Points at Dev Done in Hindsight",
                            Date = new DateTime(2012, 7, 14), 
                            BodyFile = resolveBodyPath.Invoke(@"CountingPointsAtDevDoneInHindsight.html")
                        },
                    new Article
                        {
                            Title = "The Big Refactoring or Optimization",
                            Date = new DateTime(2012, 7, 17), 
                            BodyFile = resolveBodyPath.Invoke(@"TheBigRefactoringOrOptimization.html")
                        },
                    new Article
                        {
                            Title = "Playing With Real Data",
                            Date = new DateTime(2012, 7, 20), 
                            BodyFile = resolveBodyPath.Invoke(@"PlayingWithRealData.html")
                        },
                    new Article
                        {
                            Title = "Replacing A Legacy Application",
                            Date = new DateTime(2012, 7, 23), 
                            BodyFile = resolveBodyPath.Invoke(@"ReplacingALegacyApplication.html")
                        },
                    new Article
                        {
                            Title = "Shared Responsibility and Self Organisation",
                            Date = new DateTime(2012, 7, 24), 
                            BodyFile = resolveBodyPath.Invoke(@"SharedResponsibilityAndSelfOrganisation.html")
                        },
                    new Article
                        {
                            Title = "The Adapter Pattern",
                            Date = new DateTime(2012, 7, 26), 
                            BodyFile = resolveBodyPath.Invoke(@"TheAdapterPattern.html")
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
                        },
                    new Article
                        {
                            Title = "Layers on Layers",
                            Date = new DateTime(2012, 8, 27), 
                            BodyFile = resolveBodyPath.Invoke(@"LayersOnLayers.html")
                        },
                    new Article
                        {
                            Title = "Not Configurable Is Configurable",
                            Date = new DateTime(2012, 8, 28), 
                            BodyFile = resolveBodyPath.Invoke(@"NotConfigurableIsConfigurable.html")
                        },
                    new Article
                        {
                            Title = "Post Release Tweakable Software",
                            Date = new DateTime(2012, 8, 30), 
                            BodyFile = resolveBodyPath.Invoke(@"PostReleaseTweakableSoftware.html")
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