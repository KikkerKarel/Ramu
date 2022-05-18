using Microsoft.EntityFrameworkCore;

namespace YouTube.Microservice.Model
{
    public class YouTubeDbContext : DbContext
    {
        public DbSet<Video> Video { get; set; }

        public YouTubeDbContext(DbContextOptions<YouTubeDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
