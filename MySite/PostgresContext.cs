using Microsoft.EntityFrameworkCore;

namespace MySite
{
    public class PostgresContext:DbContext
    {
        public PostgresContext()
        {
            Database.Migrate();
        }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();
            var connString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connString);
        }
    }
}
