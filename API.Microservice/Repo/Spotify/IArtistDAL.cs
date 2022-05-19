using API.Microservice.Model;
using Microsoft.AspNetCore.Http;

namespace API.Microservice.Repo.Spotify
{
    public interface IArtistDAL
    {
        public Artist GetArtistFromDb(string name);
        public List<Artist> getArtists();
        public Artist GetArtistById(string id);
        public Task<IResult> GetAboutFromScraper(string artistId);
    }
}
