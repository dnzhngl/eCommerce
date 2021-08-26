using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class RelatedProductMap :IEntityTypeConfiguration<RelatedProduct
    >
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.HasOne(p => p.Product)
                .WithMany(r => r.RelatedProducts)
                .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("RelatedProducts");
        }
    }
}