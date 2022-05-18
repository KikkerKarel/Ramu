

using SpotifyAPI.Web.Auth;

namespace API.Microservice.Authentication
{
    public interface IAuthenticator
    {
        //Task Apply(IRequest request, IAPIConnector apiConnetor);
        public Task<Uri> LoginUri();
        public Task<string> GetCallback(AuthorizationCodeResponse code);
    }
}
