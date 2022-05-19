using List.Microservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace List.Microservice.Repository
{
    public interface IListDAL
    {
        ActionResult AddToList(ListModel list);
        List<ListModel> GetList(int userId);
        ActionResult UpdateRating(int id, int rating);
        ListModel GetEntryById(int id);
        public ActionResult DeleteEntryById(int id);

    }
}
