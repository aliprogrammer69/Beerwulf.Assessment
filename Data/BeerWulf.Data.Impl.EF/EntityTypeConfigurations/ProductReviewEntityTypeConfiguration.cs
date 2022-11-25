using BeerWulf.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerWulf.Data.Impl.EF.EntityTypeConfigurations {
    public class ProductReviewEntityTypeConfiguration : IEntityTypeConfiguration<ProductReview> {
        public void Configure(EntityTypeBuilder<ProductReview> builder) {
            builder.HasKey(k => k.Id).IsClustered();

            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(p => p.Comment)
                   .IsRequired()
                   .HasMaxLength(5000);

            builder.Property(p => p.ProductRecommended)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
