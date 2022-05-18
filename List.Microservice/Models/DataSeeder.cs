namespace List.Microservice.Models
{
    public class DataSeeder
    {
        private readonly ListDbContext listDbContext;
        public DataSeeder(ListDbContext listDbContext)
        {
            this.listDbContext = listDbContext;
        }

        public void Seed()
        {
            if (!listDbContext.List.Any())
            {
                var lists = new List<ListModel>()
                {
                    new ListModel()
                    {
                        SongName = "Blinding Lights",
                        Artist = "The Weeknd",
                        Rating = 9
                    },
                    new ListModel()
                    {
                        SongName = "In The Flames",
                        Artist = "Chanmina",
                        Rating = 10
                    }
                };

                listDbContext.List.AddRange(lists);
                listDbContext.SaveChanges();
            }
        }
    }
}
