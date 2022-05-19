using API.Microservice.Model;
using API.Microservice.Repo.Spotify;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

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

        public async Task<IResult> GetAboutFromScraper(string artistId)
        {
            var artist = db.Artist.Where(x => x.Id == artistId).FirstOrDefault();
            string url = "https://localhost:7102/ramu/webscraper/scrape/about/";
            string urlParams = artist.SpotifyUrl;

            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(JsonContent.Create(urlParams));
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();
            //}

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(url, urlParams);
            response.EnsureSuccessStatusCode();

            return Results.Ok();
        }
    }
}
