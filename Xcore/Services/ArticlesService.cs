using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xcore.Contexts;
using Xcore.Models.Entities;

namespace Xcore.Services
{
    public class ArticlesService
    {

        private readonly DataContext _dataContext;

        public ArticlesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<bool> UpdateArticleAsync(ArticleEntity article)
        {
            try
            {
                _dataContext.Update(article);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            try
            {
                //_dataContext.Articles.FindAsync(id).Remove();
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<ArticleEntity> GetArticleAsync(int id)
        {
            try
            {
                var articleEntity = await _dataContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
                //var articleEntity = await _dataContext.Articles.FindAsync(id);

                if (articleEntity != null)
                {
                    return new ArticleEntity
                    {
                        Id = articleEntity.Id,
                        Title = articleEntity.Title,
                        Description = articleEntity.Description,
                        Author = articleEntity.Author,
                        Type = articleEntity.Type,
                        CreatedDate = articleEntity.CreatedDate,
                        UpdatedDate = articleEntity.UpdatedDate
                    };
                }
                return null!;
            }
            catch { return null!; }
        }

        public async Task<IActionResult> GetAllArticleAsync()
        {

            var articles = new List<ArticleEntity>();

            foreach (var article in await _dataContext.Articles.Include(x => x.Type).ToListAsync())
            {
                articles.Add(new ArticleEntity
                {
                    Id = article.Id,
                    Title = article.Title,
                    Description = article.Description,
                    Author = article.Author,
                    Type = article.Type,
                    CreatedDate = article.CreatedDate,
                    UpdatedDate = article.UpdatedDate
                });
            }

            return new OkObjectResult(articles);

        }

    }
}
