using Xcore.Contexts;
using Xcore.Models.Entities;
using Xcore.Repositories;

namespace Xcore.Services
{
    public class ArticlesAddService
    {
        private readonly ArticleRepository _articleRepository;

        public ArticlesAddService(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CreateArticle(ArticleEntity article) 
        {
            ArticleEntity articleRemade = article;
            /*
            ArticleEntity article = new ArticleEntity();
            article.Title = title;
            article.Description = description;
            article.Author = author;
            article.CreatedDate = DateTime.Now;
            article.UpdatedDate = DateTime.Now;
            */


            _articleRepository.CreateArticleAsync(articleRemade);
        }
    }
}
