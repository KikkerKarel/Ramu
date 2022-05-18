using Microsoft.AspNetCore.Mvc;
using User.Microservice.Models;

namespace User.Microservice.Repository
{
    public interface IUserDAL
    {
        UserModel Login(UserLogin login);
        public void Register(UserModel user);
        List<UserModel> GetUsers();
        UserModel UpdateUser(UserModel user);
        UserModel GetUserById(int id);
        public ActionResult DeleteUserById(int id);
    }
}
