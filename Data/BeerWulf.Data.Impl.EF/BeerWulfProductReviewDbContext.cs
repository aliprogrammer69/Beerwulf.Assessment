using BeerWulf.Data.Impl.EF.EntityTypeConfigurations;
using BeerWulf.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace BeerWulf.Data.Impl.EF {
    public class BeerWulfProductReviewDbContext : DbContext {
        public BeerWulfProductReviewDbContext(DbContextOptions<BeerWulfProductReviewDbContext> options)
            : base(options) {
        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("Product");

            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductReviewEntityTypeConfiguration());
        }
    }
}
