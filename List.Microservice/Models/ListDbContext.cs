using Microsoft.EntityFrameworkCore;

namespace List.Microservice.Models
{
    public class ListDbContext : DbContext
    {
        public DbSet<ListModel> List { get; set; }

        public ListDbContext(DbContextOptions<ListDbContext> options)
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
