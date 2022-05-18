using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace API.Microservice.Authentication
{
    public class Authenticator : IAuthenticator
    {
        private readonly string client_id = "2e4fc1060942420b9462bf2151989e37";
        private readonly string client_secret = "9dacfaa3cc0f4250ac12a1273dd87a92";

        public async Task<Uri> LoginUri()
        {
            var loginRequest = new LoginRequest(
                new Uri("http://localhost:3000/"),
                client_id,
                LoginRequest.ResponseType.Code
            )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative, Scopes.Streaming }
            };

            var uri = loginRequest.ToUri();

            return uri;
        }

        public async Task<string> GetCallback(AuthorizationCodeResponse response)
        {
            var config = SpotifyClientConfig.CreateDefault();
            var tokenResponse = await new OAuthClient(config).RequestToken(
                new AuthorizationCodeTokenRequest(
                client_id, client_secret, response.Code, new Uri("http://localhost:3000/")
                )
            );

            if (tokenResponse.IsExpired)
            {
                var newResponse = await new OAuthClient(config).RequestToken(
                    new AuthorizationCodeRefreshRequest(client_id, client_secret, tokenResponse.RefreshToken));

                var spotify = new SpotifyClient(newResponse.AccessToken);
                return newResponse.AccessToken;
            }
            else
            {
                var spotify = new SpotifyClient(tokenResponse.AccessToken);
                return tokenResponse.AccessToken;
            }
        }
    }
}
