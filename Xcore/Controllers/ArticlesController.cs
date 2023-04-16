using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Xcore.Contexts;
using Xcore.Interfaces;
using Xcore.Models;
using Xcore.Models.Entities;
using Xcore.Services;

namespace Xcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticlesAddService _articlesAddService;
        private readonly ArticlesService _articlesService;
        private readonly DataContext _dataContext;

        public ArticlesController(ArticlesAddService articlesAddService, ArticlesService articlesService, DataContext dataContext)
        {
            _articlesAddService = articlesAddService;
            _articlesService = articlesService;
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article model)
        {
            if (ModelState.IsValid)
            {
                var articleEntity = new ArticleEntity
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = model.Author,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Type = model.Type
                };
                _articlesAddService.CreateArticle(articleEntity);
                return new OkResult();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var articleEntity = await _dataContext.Articles.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == id);
            

            if (articleEntity != null)
              {
                var articles = new ArticleEntity{
                    Id = articleEntity.Id,
                    Title = articleEntity.Title,
                    Description = articleEntity.Description,
                    Author = articleEntity.Author,
                    CreatedDate = articleEntity.CreatedDate,
                    UpdatedDate = articleEntity.UpdatedDate,
                        Type = articleEntity.Type
                };
                return new OkObjectResult(articles);
            }
              return new NotFoundResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
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

        [HttpPut]
        public IActionResult Update(int id, Article model) 
        {
            if (ModelState.IsValid)
            {
                var articleEntity = new ArticleEntity
                {
                    Id = id,
                    Title = model.Title,
                    Description = model.Description,
                    Author = model.Author,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Type = model.Type
                };
                _articlesService.UpdateArticleAsync(articleEntity);
                return new OkResult();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var articleEntity = await _dataContext.Articles.FindAsync(id);
            if (articleEntity == null)
            {
                return NotFound();
            }

            _dataContext.Articles.Remove(articleEntity);
            await _dataContext.SaveChangesAsync();

            return NoContent();


        }

        //[HttpGet("{type}")]
        //public IActionResult GetAllType(int type)
        //{

        //    return Ok();
        //}
    }
}
