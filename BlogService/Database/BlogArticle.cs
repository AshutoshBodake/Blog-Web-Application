using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService.Database
{
    public class BlogArticle
    {
        public int BlogArticleId { get; set; }
        public string  BlogContent { get; set; }
        public string BlogTitle { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public int NoOfViews { get; set; }
        public int NoOfLikes { get; set; }
        public DateTime? BlogArticleCreatedOn { get; set; }
        public ICollection<BlogComment> Blogcomments { get; set; }
        public bool? IsDisplay { get; set; }
    }
}
