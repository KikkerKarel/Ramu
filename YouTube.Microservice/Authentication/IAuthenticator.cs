namespace YouTube.Microservice.Authentication
{
    public interface IAuthenticator
    {
        public Task<IResult> Login();
    }
}
