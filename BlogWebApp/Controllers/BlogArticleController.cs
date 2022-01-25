using BlogService.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogWebApp.Controllers
{
    public class BlogArticleController : Controller
    {
        IConfiguration _config;
        HttpClient _client;
        Uri _baseAddress;

        public BlogArticleController(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
            _config = config;
            _baseAddress = new Uri(_config["ApiAddress"]);
            _client.BaseAddress = _baseAddress;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogArticles()
        {
            IEnumerable<BlogArticle> blogArticles = null;
            var response = _client.GetAsync((_client.BaseAddress + "Blog/GetBlogArticles")).Result;  
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<IEnumerable<BlogArticle>>();
                readTask.Wait();
                blogArticles = readTask.Result;
            }
            return View(blogArticles);
        }

        [HttpGet]
        public IActionResult GetBlogArticle(int id)
        {
            BlogArticle blogArticle = null;
            var response = _client.GetAsync((_client.BaseAddress + "Blog/GetBlogArticleById?BlogArticleId=" + id)).Result;
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<BlogArticle>();
                readTask.Wait();
                //JsonSerializer
                blogArticle = readTask.Result;
            }

           // string apiUrl = "http://localhost:58764/api/values";

            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(apiUrl);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = await response.Content.ReadAsStringAsync();
            //        var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
            //    }
            //}

            return View("./Article", blogArticle);
        }
    }
}
