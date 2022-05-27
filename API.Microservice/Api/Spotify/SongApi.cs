using API.Microservice.Model;
using SpotifyAPI.Web;

namespace API.Microservice.Api.Spotify
{
    public class SongApi : ISongApi
    {
        private readonly ApiDbContext db;
        public SongApi(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Song>> GetSongsByArtistFromApi(string artistName, string tokenHash)
        {
            string decoded;
            byte[] data = Convert.FromBase64String(tokenHash);
            decoded = System.Text.Encoding.ASCII.GetString(data);
            var spotify = new SpotifyClient(decoded);

            var query = "artist:" + artistName;
            var request = new SearchRequest(SearchRequest.Types.Track, query)
            {
                Market = "NL",
                Limit = 50,
                Offset = 0,
            };

            var response = await spotify.Search.Item(request);
            List<Song> songs = new List<Song>();

            Artist a = db.Artist.Where(s => s.Id == response.Tracks.Items[0].Artists[0].Id).FirstOrDefault();

            if (a == null)
            {
                return null;
            }

            foreach (var item in response.Tracks.Items)
            {
                songs.Add(new Song()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Popularity = item.Popularity,
                    //Duration = (int)TimeSpan.FromMilliseconds(item.DurationMs).TotalMinutes,
                    Duration = item.DurationMs,
                    ArtistId = a.Id,
                    Image = item.Album.Images[0].Url,
                });
            };

            foreach (var song in songs)
            {
                if (db.Song.Any(s => s.Id == song.Id))
                {
                    return null;
                }
            }

            db.Song.AddRange(songs);
            db.SaveChanges();

            return songs;
        }
    }
}
