using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using User.Microservice.Models;
using User.Microservice.Repository;

namespace User.Microservice.Test.Stubs
{
    internal class UserDALStub : IUserDAL
    {
        public bool? testValue = null;

        public UserModel Login(UserLogin login)
        {
            if (testValue == true)
            {
                return new UserModel();
            }
            else
            {
                return null;
            }
        }

        public void Register(UserModel model)
        {
            if (testValue == true)
            {

            }
            else
            {

            }
        }

        public List<UserModel> GetUsers()
        {
            if (testValue == true)
            {
                return new List<UserModel>();
            }
            else
            {
                return null;
            }
        }

        public UserModel UpdateUser(UserModel user)
        {
            if (testValue == true)
            {
                return new UserModel();
            }
            else
            {
                return null;
            }
        }

        public UserModel GetUserById(int id)
        {
            return new UserModel();
        }

        public ActionResult DeleteUserById(int id)
        {
            if (testValue == true)
            {
                return new OkResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
