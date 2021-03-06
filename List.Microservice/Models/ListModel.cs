using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace List.Microservice.Models
{
    public class ListModel
    {
        [Key]
        public int Id { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }
        public int Rating { get; set; }
    }
}
