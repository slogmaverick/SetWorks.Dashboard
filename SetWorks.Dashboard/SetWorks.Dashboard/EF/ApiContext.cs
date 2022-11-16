using Microsoft.EntityFrameworkCore;

namespace SetWorks.Dashboard.EF
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CovidDB");
        }

        public DbSet<RonaStateSummary> CovidData { get; set; }
    }
}
