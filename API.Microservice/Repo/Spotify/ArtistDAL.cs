using API.Microservice.Model;
using API.Microservice.Repo.Spotify;

namespace API.Microservice.Repo.Spotify
{
    public class ArtistDAL : IArtistDAL
    {
        private readonly ApiDbContext db;
        public ArtistDAL(ApiDbContext db)
        {
            this.db = db;
        }

        public Artist GetArtistFromDb(string name)
        {
            return db.Artist.Where(x => x.Name == name).FirstOrDefault();
        }

        public List<Artist> getArtists() => db.Artist.ToList(); 

        public Artist GetArtistById(string id)
        {
            return db.Artist.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
