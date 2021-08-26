using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class FavoriteProductMap : IEntityTypeConfiguration<FavoriteProduct>
    {
        public void Configure(EntityTypeBuilder<FavoriteProduct> builder)
        {
            builder.HasOne(x => x.Account)
                .WithMany(x => x.FavoriteProducts)
                .HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.FavoriteProducts)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("FavoriteProducts");
        }
    }
}