using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.Models;
using Blog.Presenters;
using Blog.Repositories;

namespace Blog.Services
{
    public class ArticleService : IArticleService
    {
        private const int FullArticleCount = 2;
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            Mapper.CreateMap<Article, ArticlePresenter>();
            Mapper.CreateMap<Article, ArticleIndexPresenter>();
            this.articleRepository = articleRepository;
        }

        public MultipleArticlePresenter Home()
        {
            var articles = articleRepository.All();
            var fullArticles = articles.Take(FullArticleCount).ToList();
            var indexes = articles.Skip(FullArticleCount).ToList();
            return CreateMultipleArticlePresenter(fullArticles, indexes, "Other Articles");
        }

        public MultipleArticlePresenter Article(string slugTitle)
        {
            var fullArticles = new List<Article> { articleRepository.Retrieve(slugTitle) };
            var indexes = articleRepository.AllWhereNot(slugTitle);
            return CreateMultipleArticlePresenter(fullArticles, indexes, "Other Articles");
        }

        public MultipleArticleIndexPresenter Index()
        {
            return new MultipleArticleIndexPresenter
                {
                    Title = "Article Index", 
                    Articles = MapIndexes(articleRepository.All())
                };
        }

        private static MultipleArticlePresenter CreateMultipleArticlePresenter(IList<Article> fullArticles, IList<Article> indexes, string indexesTitle)
        {
            var multipleArticlePresenter = new MultipleArticlePresenter
            {
                Articles = Map(fullArticles),
            };
            multipleArticlePresenter.Index.Title = indexesTitle;
            multipleArticlePresenter.Index.Articles = MapIndexes(indexes);
            return multipleArticlePresenter;
        }

        private static IList<ArticleIndexPresenter> MapIndexes(IList<Article> articles)
        {
            return Mapper.Map<IList<Article>, IList<ArticleIndexPresenter>>(articles);
        }

        private static IList<ArticlePresenter> Map(IList<Article> articles)
        {
            return Mapper.Map<IList<Article>, IList<ArticlePresenter>>(articles);
        }

        private static ArticlePresenter Map(Article article)
        {
            return Mapper.Map<Article, ArticlePresenter>(article);
        }
    }
}