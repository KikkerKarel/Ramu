using API.Microservice.Model;
using SpotifyAPI.Web;

namespace API.Microservice.Api.Spotify
{
    public class ArtistApi : IArtistApi
    {
        private readonly ApiDbContext db;

        public ArtistApi(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<Artist> SearchArtist(string name, string tokenHash)
        {
            string decoded;
            byte[] data = Convert.FromBase64String(tokenHash);
            decoded = System.Text.Encoding.ASCII.GetString(data);
            var spotify = new SpotifyClient(decoded);

            var query = "artist:" + name;
            var request = new SearchRequest(SearchRequest.Types.Artist, query)
            {
                Market = "NL",
                Limit = 1,
                Offset = 0,
            };

            var response = await spotify.Search.Item(request);
            var newArtist = new Artist();

            response.Artists.Items.ForEach(item =>
            {
                newArtist.Name = item.Name;
                newArtist.Id = item.Id;
                newArtist.Followers = item.Followers.Total;
                newArtist.Popularity = item.Popularity;
                newArtist.SpotifyUrl = item.ExternalUrls.First().Value;
                item.Images.ForEach(image =>
                {
                    if (image.Height == 640 && image.Width == 640)
                    {
                        newArtist.Image = image.Url;
                    }
                });
            });

            if (db.Artist.Any(x => x.Name == newArtist.Name))
            {
                db.Artist.Update(newArtist);
                db.SaveChanges();
                return db.Artist.Where(x => x.Name == newArtist.Name).FirstOrDefault();
            }
            else
            {
                db.Artist.Add(newArtist);
                db.SaveChanges();

                return newArtist;
            }
        }
    }
}
