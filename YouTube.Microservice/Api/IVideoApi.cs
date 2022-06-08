namespace YouTube.Microservice.Api
{
    public interface IVideoApi
    {
        public Task<IResult> Search(string query);
    }
}
