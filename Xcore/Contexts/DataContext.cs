using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xcore.Models.Entities;

namespace Xcore.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContentTypeEntity> ContentTypes { get; set; }
        public DbSet<ArticleEntity> Articles { get; set; }

    }
}
