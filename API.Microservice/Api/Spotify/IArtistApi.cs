using API.Microservice.Model;

namespace API.Microservice.Api.Spotify
{
    public interface IArtistApi
    {
        public Task<Artist> SearchArtist(string name, string access_token);
    }
}
