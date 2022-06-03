using API.Microservice.Model;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace API.Microservice.Repo.Spotify
{
    public class ArtistDAL : IArtistDAL
    {
        private readonly ApiDbContext db;
        private static readonly HttpClient client = new HttpClient();
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

        //public async Task<IResult> GetAboutFromScraper(string artistId)
        //{
        //    var artist = db.Artist.Where(x => x.Id == artistId).FirstOrDefault();
        //    //string url = "https://localhost:7102/ramu/webscraper/scrape/about/";

        //    string json = JsonConvert.SerializeObject(artist.SpotifyUrl);
        //    //client.BaseAddress = new Uri("https://localhost:7102/");
        //    //var response = client.PostAsJsonAsync("ramu/webscraper/scrape/about", json).Result;

        //    //response.EnsureSuccessStatusCode();
        //    WebRequest request = WebRequest.Create("https://localhost:7102/ramu/webscraper/scrape/about");
        //    request.ContentType = "application/json";

        //    request.Method = "POST";
        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    byte[] data = encoding.GetBytes(json);
        //    request.ContentLength = data.Length;
        //    Stream newStream = request.GetRequestStream();
        //    newStream.Write(data, 0, data.Length);
        //    newStream.Close();

        //    string text;
        //    var response = (HttpWebResponse)request.GetResponse();

        //    using (var sr = new StreamReader(response.GetResponseStream()))
        //    {
        //        text = sr.ReadToEnd();
        //    }

        //        return Results.Ok();
        //}

        public IResult AddAbout(string artistId, string about)
        {
            var artist = db.Artist.FirstOrDefault(x => x.Id == artistId);
            if (artist != null)
            {
                artist.About = about;
                db.SaveChanges();
                return Results.Ok(artist);
            }
            else
            {
                return Results.Problem( detail: "entity is empty");
            }
        }
    }
}
