using API.Microservice.Model;

namespace API.Microservice.Repo.Spotify
{
    public interface ISongDAL
    {
        public Song getSongFromDb(string name);
        public List<Song> getAllSongs();
        public Song getSongById(string id);
        public List<Song> getSongsByArtistId(string artistId);
    }
}
