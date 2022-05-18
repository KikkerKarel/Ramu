using API.Microservice.Model;

namespace API.Microservice.Repo.Spotify
{
    public class SongDAL : ISongDAL
    {
        private readonly ApiDbContext db;
        public SongDAL(ApiDbContext db)
        {
            this.db = db;
        }
        public Song getSongFromDb(string name)
        {
            return db.Song.Where(x => x.Name == name).FirstOrDefault();
        }

        public List<Song> getAllSongs() => db.Song.ToList();
        public Song getSongById(string id)
        {
            return db.Song.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
