using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService.Database
{
    public class BlogCategory
    {
        public int BlogCategoryId { get; set; }
        public string Category { get; set; }
        public bool? IsDisplay { get; set; }
        public ICollection<BlogArticle> Blogs { get; set; }
        public DateTime? BlogCategoryCreatedOn { get; set; }
    }
}
