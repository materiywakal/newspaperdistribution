using Microsoft.EntityFrameworkCore;
using NewspaperDistribution.DAL.DatabaseModelConfiguration;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PrintingHouseModel> PrintingHouses { get; set; }
        public DbSet<PostalOfficeModel> PostalOffices { get; set; }
        public DbSet<NewspaperModel> Newspapers { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PrintingHouseModelConfiguration());
            modelBuilder.ApplyConfiguration(new PostalOfficeModelConfiguration());
            modelBuilder.ApplyConfiguration(new NewspaperModelConfiguration());
        }
    }
}
