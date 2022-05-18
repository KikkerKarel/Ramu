using Microsoft.AspNetCore.Mvc;
using User.Microservice.Models;
namespace User.Microservice.Repository
{
    public class UserDAL : IUserDAL
    {
        private readonly UserDbContext db;

        public UserDAL(UserDbContext db)
        {
            this.db = db;
        }

        public UserModel Login(UserLogin login)
        {

            var user = db.User.SingleOrDefault(x => x.Username == login.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
                throw new Exception("Username or password is incorrect");

            return user;
        }

        public void Register(UserModel model)
        {
            if (db.User.Any(x => x.Username == model.Username))
                throw new ApplicationException("Username '" + model.Username + "' is already taken");

            var user = model;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);

            db.User.Add(user);
            db.SaveChanges();
        }


        public List<UserModel> GetUsers() => db.User.ToList();

        public UserModel UpdateUser(UserModel user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.Where(x => x.Id == user.Id).FirstOrDefault();
        }

        public UserModel GetUserById(int id)
        {
            return db.User.Where(x => x.Id == id).FirstOrDefault();
        }

        public ActionResult DeleteUserById(int id)
        {
            db.User.Remove(db.User.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
