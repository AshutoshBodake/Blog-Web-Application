using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService.Database
{
    public class BlogComment
    {
        public int BlogCommentId { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentCreatedOn { get; set; }
        public int BlogArticleId { get; set; }
        public BlogArticle Blog { get; set; }
        public bool? IsDisplay { get; set; }
    }
}
