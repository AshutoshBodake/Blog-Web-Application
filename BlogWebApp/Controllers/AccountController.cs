using AuthenticationService.Models;
using BlogWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogWebApp.Controllers
{
    public class AccountController : Controller
    {
        IConfiguration _config;
        HttpClient _client;
        Uri _baseAddress;
        public AccountController(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
            _config = config;
            _baseAddress = new Uri(_config["ApiAddress"]);
            _client.BaseAddress = _baseAddress;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            string strData = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_client.BaseAddress + "auth/authenticateUser", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var strUser = response.Content.ReadAsStringAsync().Result;
                UserModel user = JsonSerializer.Deserialize<UserModel>(strUser);

                return RedirectToAction("Index", "Dashboard", new { area = "User" });
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserSignUpModel model)
        {
            string strData = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_client.BaseAddress + "/auth/createuser", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
