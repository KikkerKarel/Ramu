using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.YouTube.v3;

namespace YouTube.Microservice.Authentication
{
    public class Authenticator : IAuthenticator
    {
        public async Task<IResult> Login()
        {
            var builder = WebApplication.CreateBuilder();
            string[] scopes = { "https://www.googleapis.com/auth/youtube" };
            var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = builder.Configuration["Authentication:Google:ClientId"],
                    ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]
                },
                scopes, "user", CancellationToken.None).Result;

            if (credentials.Token.IsExpired(SystemClock.Default))
                credentials.RefreshTokenAsync(CancellationToken.None).Wait();

            return Results.Ok(credentials);
            //var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credentials
            //});

            //var request = youtubeService.Channels.List("id");
            //request.Mine = true;
            //var list = request.Execute();
        }
    }
}
