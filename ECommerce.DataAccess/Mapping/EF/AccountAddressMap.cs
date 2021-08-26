using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class AccountAddressMap : IEntityTypeConfiguration<AccountAddress>
    {
        public void Configure(EntityTypeBuilder<AccountAddress> builder)
        {
            builder.HasOne(x => x.Account)
                .WithMany(x => x.AccountAddresses)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("AccountAddresses");
        }
    }
}