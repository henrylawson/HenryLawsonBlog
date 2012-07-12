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
            var multipleArticlePresenter = new MultipleArticlePresenter
                {
                    Articles = Map(articles.Take(FullArticleCount).ToList()),
                };
            multipleArticlePresenter.Index.Title = "Other Articles";
            multipleArticlePresenter.Index.Articles = MapIndexes(articles.Skip(FullArticleCount).ToList());
            return multipleArticlePresenter;
        }

        public ArticlePresenter Article(string slugTitle)
        {
            return Map(articleRepository.Retrieve(slugTitle));
        }

        public MultipleArticleIndexPresenter Index()
        {
            return new MultipleArticleIndexPresenter
                {
                    Title = "Article Index", 
                    Articles = MapIndexes(articleRepository.All())
                };
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