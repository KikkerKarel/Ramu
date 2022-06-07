using Microsoft.EntityFrameworkCore;
using YouTube.Microservice.Model;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.Google;
using YouTube.Microservice.Authentication;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");

builder.Services.AddDbContext<YouTubeDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuthenticator, Authenticator>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddGoogle(googleOptions => {
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapPost("/youtube/login", ([FromServices] IAuthenticator yt) =>
{
    return yt.Login();
});

app.Run();
