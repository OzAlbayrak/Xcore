using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Xcore.Models.Entities
{
    public class ContentTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
