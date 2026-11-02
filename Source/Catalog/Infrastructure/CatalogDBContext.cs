using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
    {
        public DbSet<Merchant> Merchants => Set<Merchant>();
        public DbSet<Catalog> Catalogs => Set<Catalog>();
        public DbSet<CatalogItem> CatalogItems => Set<CatalogItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>()
                .Property(i => i.Price)
                .HasPrecision(18, 2);

            SeedData.Seed(modelBuilder);
        }
    }
}
