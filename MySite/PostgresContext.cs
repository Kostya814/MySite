using Microsoft.EntityFrameworkCore;

namespace MySite
{
    public class PostgresContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=Q1w2e3r4;Database=db_fermermarket");
    }
}
