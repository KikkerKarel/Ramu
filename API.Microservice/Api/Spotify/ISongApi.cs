using API.Microservice.Model;

namespace API.Microservice.Api.Spotify
{
    public interface ISongApi
    {
        public Task<List<Song>> GetSongsByArtistFromApi(string artistName, string tokenHash);
    }
}
