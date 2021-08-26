using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => p.Url).IsUnique();
            builder.Property(p => p.BrandId).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Price).IsRequired();

            builder.ToTable("Products");
        }
    }
}