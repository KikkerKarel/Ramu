using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Microservice.Model
{
    public class Spotify
    {
    }

    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public string Image { get; set; }
        public string? Banner { get; set; }
        public string? SpotifyUrl { get; set; }
        public string? About { get; set; }
        public List<Song> Songs { get; set; }
    }

    public class Song
    {
        [Required]
        public string Id { get; set; }
        [ForeignKey("ArtistId")]
        public string? ArtistId { get; set; }
        public Artist artist { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public int Duration { get; set; }
        public string? Image { get; set; }
    }


}
