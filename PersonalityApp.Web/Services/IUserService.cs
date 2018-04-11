using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Domain.Requests;
using System.Collections.Generic;

namespace PersonalityApp.Web.Services
{
    public interface IUserService
    {
        //int LoginUser(LoginRequest model);
        User GetUserById(int id);
        int UpdateUser(int id, UpdateUserRequest User);
        List<User> GetUsers();
    }
}