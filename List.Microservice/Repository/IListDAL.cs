using List.Microservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace List.Microservice.Repository
{
    public interface IListDAL
    {
        ActionResult AddToList(ListModel list);
        List<ListModel> GetList();
        ListModel GetEntryById(int id);
        public ActionResult DeleteEntryById(int id);

    }
}
