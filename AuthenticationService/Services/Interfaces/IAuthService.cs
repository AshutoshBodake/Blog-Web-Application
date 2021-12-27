using AuthenticationService.Database;
using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> AuthenticateUser(LoginModel model);
        Task<bool> CreateUser(User model, string Password);
        Task<bool> SignOut();
    }
}
