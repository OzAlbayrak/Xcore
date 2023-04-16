using Xcore.Interfaces;
using Xcore.Models.Entities;

namespace Xcore.Models
{
    public class Article : Dates, IArticle
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public override DateTime CreatedDate { get; set; }
        public ContentTypeEntity Type { get; set; }
     
    }
}
