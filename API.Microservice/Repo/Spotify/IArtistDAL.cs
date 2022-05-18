using API.Microservice.Model;

namespace API.Microservice.Repo.Spotify
{
    public interface IArtistDAL
    {
        public Artist GetArtistFromDb(string name);
        public List<Artist> getArtists();
        public Artist GetArtistById(string id);
    }
}
