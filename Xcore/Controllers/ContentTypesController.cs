using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xcore.Models.Entities;
using Xcore.Models;
using Xcore.Services;
using Xcore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Xcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentTypesController : ControllerBase
    {
        private readonly ContentTypesService _contentTypesService;
        private readonly DataContext _dataContext;

        public ContentTypesController(ContentTypesService contentTypesService, DataContext dataContext)
        {
            _contentTypesService = contentTypesService;
            _dataContext = dataContext;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ContentType model)
        {
            if (ModelState.IsValid)
            {
                var contentTypeEntity = new ContentTypeEntity
                {
                    Name = model.Name
                };
                _contentTypesService.CreateContentTypesAsync(contentTypeEntity);
                return new OkResult();
            }
            return BadRequest();
        }

        [HttpGet("{GetByType}")]
        public async Task<IActionResult> GetAllByType(int GetByType)
        {

            var articles = new List<ArticleEntity>();

            foreach (var article in await _dataContext.Articles.Include(x => x.Type).ToListAsync())
            {
                if (article.Type.Id == GetByType) 
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
            }

            return new OkObjectResult(articles);
        }


    }
}
