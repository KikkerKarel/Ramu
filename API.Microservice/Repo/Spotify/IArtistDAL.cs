using API.Microservice.Model;

namespace API.Microservice.Repo.Spotify
{
    public interface IArtistDAL
    {
        public Artist GetArtistFromDb(string name);
        public List<Artist> getArtists();
        public Artist GetArtistById(string id);
        //public Task<IResult> GetAboutFromScraper(string artistId);
        public IResult AddAbout(string artistId, string about);
    }
}
