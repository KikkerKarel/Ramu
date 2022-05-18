namespace API.Microservice.Model
{
    public class DataSeeder
    {
        private readonly ApiDbContext apiDbContext;
        public DataSeeder(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public void Seed()
        {
            if (!apiDbContext.Artist.Any())
            {
                var artists = new List<Artist>()
                {
                    new Artist()
                    {
                        Id = "1uNFoZAHBGtllmzznpCI3s",
                        Name = "Justin Bieber",
                        Popularity = 94,
                        Followers = 60436534,
                        Image = "https://i.scdn.co/image/ab6761610000e5eb8ae7f2aaa9817a704a87ea36"
                        //Images =
                        //{
                        //    new Image()
                        //    {
                        //        height = 640,
                        //        url = "https://i.scdn.co/image/ab6761610000e5eb8ae7f2aaa9817a704a87ea36",
                        //        width = 640
                        //    }
                        //}
                    }
                };

                apiDbContext.Artist.AddRange(artists);
                apiDbContext.SaveChanges();
            }
        }
    }
}
