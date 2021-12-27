using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions <DatabaseContext> options):base(options)
        {

        }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogArticle> BlogArticles { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
    }
}
