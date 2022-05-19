using List.Microservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace List.Microservice.Repository
{
    public class ListDAL : IListDAL
    {
        private readonly ListDbContext db;

        public ListDAL(ListDbContext db)
        {
            this.db = db;
        }

        public List<ListModel> GetList(int userId)
        {
            return db.List.Where(x => x.UserId == userId).ToList();
        }

        public ListModel GetEntryById(int id)
        {
            return db.List.Where(x => x.Id == id).FirstOrDefault();
        }

        public ActionResult AddToList(ListModel list)
        {
            db.List.Add(list);
            db.SaveChanges();
            return new OkResult();
        }

        public ActionResult UpdateRating(int id, int rating)
        {
            var list = new ListModel() { Id = id, Rating = rating };
            db.List.Attach(list);
            db.Entry(list).Property(x => x.Rating).IsModified = true;
            db.SaveChanges();
            return new OkResult();
        }

        public ActionResult DeleteEntryById(int id)
        {
            db.List.Remove(db.List.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }

    }
}
