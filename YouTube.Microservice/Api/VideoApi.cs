using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using YouTube.Microservice.Model;

namespace YouTube.Microservice.Api
{
    public class VideoApi : IVideoApi
    {
        private readonly YouTubeDbContext db;

        public VideoApi(YouTubeDbContext db)
        {
            this.db = db;
        }
        public async Task<IResult> Search(string query)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAbEq-YUz4Q_A6d6AaebnaYFLh0pt0tWto",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = query; //replace with your search term.
            searchListRequest.MaxResults = 50;

            var searchLisResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();

            foreach (var searchResult in searchLisResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        break;
                }
            }

            return Results.Ok(videos);
        }
    }
}
