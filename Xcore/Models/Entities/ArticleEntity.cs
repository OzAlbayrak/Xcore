using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Xcore.Interfaces;

namespace Xcore.Models.Entities
{
    public class ArticleEntity : Dates, IArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public ContentTypeEntity Type { get; set; }
    }
}
