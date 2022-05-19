using API.Microservice.Api.Spotify;
using API.Microservice.Authentication;
using API.Microservice.Model;
using API.Microservice.Repo.Spotify;
using API.Microservice.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Web.Auth;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IAuthenticator, Authenticator>();
builder.Services.AddScoped<IArtistApi, ArtistApi>();
builder.Services.AddScoped<IArtistDAL, ArtistDAL>();
builder.Services.AddScoped<ISongApi, SongApi>();
builder.Services.AddScoped<ISongDAL, SongDAL>();
builder.Services.AddScoped<IWebScaper, Webscraper>();
builder.Services.AddDbContext<ApiDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddAuthentication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//login
app.MapPost("/spotify/api/login", ([FromServices] IAuthenticator auth) =>
{
    return auth.LoginUri();
});

app.MapPost("spotify/api/callback", ([FromServices] IAuthenticator auth, AuthorizationCodeResponse code) =>
{
    return auth.GetCallback(code);
});

//Artist calls
app.MapGet("/spotify/api/search/artist", ([FromServices] IArtistApi api, string name, string tokenHash) => {
    return api.SearchArtist(name, tokenHash);
});

app.MapGet("/spotify/db/artist/get/{name}", ([FromServices] IArtistDAL db, string name) =>
{
    return db.GetArtistFromDb(name);
});

app.MapGet("/spotify/db/artist/get/id/{id}", ([FromServices] IArtistDAL db, string id) =>
{
    return db.GetArtistById(id);
});

app.MapGet("/api/db/artist/get/all", ([FromServices] IArtistDAL db) =>
{
    return db.getArtists();
});

//Song calls
app.MapGet("/spotify/api/search/song", ([FromServices] ISongApi api, string artistName, string tokenHash) => {
    return api.GetSongsByArtistFromApi(artistName, tokenHash);
});

app.MapGet("/test/scape", ([FromServices] IWebScaper webScraper) =>
{
    return webScraper.Scrape();
});

app.MapGet("/api/db/song/get/{name}", ([FromServices] ISongDAL db, string name) =>
{
    return db.getSongFromDb(name);
});

app.MapGet("/api/db/song/get/all", ([FromServices] ISongDAL db) =>
{
    return db.getAllSongs();
});

app.MapGet("/api/db/song/get/id/{id}", ([FromServices] ISongDAL db, string id) =>
{
    return db.getSongById(id);
});

//Webscraper calls
app.MapGet("/api/scrape/get/about", ([FromServices] IArtistDAL api, string artistId) =>
{
    return api.GetAboutFromScraper(artistId);
});

app.Run();

public partial class Program { }
