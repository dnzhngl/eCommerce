using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class ProductGroupLineMap: IEntityTypeConfiguration<ProductGroupLine>
    {
        public void Configure(EntityTypeBuilder<ProductGroupLine> builder)
        {
            builder.HasOne(x => x.ProductGroup)
                .WithMany(x => x.ProductGroupLines)
                .HasForeignKey(x => x.ProductGroupId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("ProductGroupLines");
        }
    }
}