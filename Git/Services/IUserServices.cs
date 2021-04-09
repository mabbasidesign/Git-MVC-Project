using Git.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git.Services
{
    interface IUserServices
    {
        string CreateUser(RegisterInputModel inputModel);
        string GetUserId(LoginInputViewModel inputViewModel);
        bool IsEmailAvailable(string email);
        bool IsUsernameAvailable(string username);
    }
}
