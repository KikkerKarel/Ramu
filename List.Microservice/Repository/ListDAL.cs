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

        public List<ListModel> GetList() => db.List.ToList();

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

        public ActionResult DeleteEntryById(int id)
        {
            db.List.Remove(db.List.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }

    }
}
