using AuthenticationService.Database;
using AuthenticationService.Models;
using AuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Services.Implementations
{
    public class AuthService : IAuthService
    {
        SignInManager<User> _signInManager;
        UserManager<User> _userManager;
        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<UserModel> AuthenticateUser(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var roles = await _userManager.GetRolesAsync(user);
                if (user != null)
                {
                    UserModel userModel = new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = roles.ToArray()
                    };
                    return userModel;
                }
            }
            return null;
        }

        public async Task<bool> CreateUser(User model, string Password)
        {
            var result = await _userManager.CreateAsync(model, Password);
            if (result.Succeeded)
            {
                //Admin, User
                string Role = "User";
                var res = await _userManager.AddToRoleAsync(model, Role);
                return res.Succeeded;
            }
            return false;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _userManager.Users.Select(user => new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            }).ToListAsync();
            return users;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
