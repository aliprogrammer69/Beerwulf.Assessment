using BeerWulf.Data.Impl.EF.Seed;
using BeerWulf.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerWulf.Data.Impl.EF.EntityTypeConfigurations {
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.HasKey(p => p.Id).IsClustered();

            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(512);

            builder.Property(p => p.Description)
                   .HasMaxLength(4000);

            builder.HasData(SeedProducts.Products);
        }
    }
}
