using BlogService.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        DatabaseContext _db;

        public BlogController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetBlogCategories")] //For multiple httpget methods. You can also mention at controller like this [Route("api/[controller]/[action]")] //above the controller class
        public IEnumerable<BlogCategory> GetBlogCategories()
        {
            return _db.BlogCategories;
        }

        [HttpGet]
        [Route("GetBlogArticles")]
        public IEnumerable<BlogArticle> GetBlogArticles()
        {
            return _db.BlogArticles;
        }

        [HttpGet("{BlogArticleId}")]
        public BlogArticle GetBlogArticles(int BlogArticleId)
        {
            return _db.BlogArticles.Find(BlogArticleId);
        }

        [HttpGet("{BlogCategoryId}")]
        public IEnumerable<BlogArticle> GetBlogArticlesByCategory(int BlogCategoryId)
        {
            return (IEnumerable<BlogArticle>)_db.BlogArticles.Select(ba => ba.BlogCategoryId == BlogCategoryId);
        }

        [HttpPost]
        public IActionResult AddBlogArticle(BlogArticle article)
        {
            try
            {
                _db.BlogArticles.Add(article);
                _db.SaveChanges();
                return Created("/api/created", article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
