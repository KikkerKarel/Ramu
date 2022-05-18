namespace User.Microservice.Models
{
    public class DataSeeder
    {
        private readonly UserDbContext userDbContext;
        public DataSeeder(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void Seed()
        {
            if (!userDbContext.User.Any())
            {
                var users = new List<UserModel>()
                {
                    new UserModel()
                    {
                        Username = "Jantje",
                        PasswordHash = "JantjeIsCool",
                        Email = "Jantje@stoer.com",
                    },
                    new UserModel()
                    {
                        Username = "Antoon",
                        PasswordHash = "AntoonIsCool",
                        Email = "Antoon@stoer.com",
                    }
                };

                userDbContext.User.AddRange(users);
                userDbContext.SaveChanges();
            }
        }
    }
}
