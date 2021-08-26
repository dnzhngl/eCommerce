using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.FirstName).HasMaxLength(25).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(25).IsRequired();
            builder.Property(a => a.Gsm).IsFixedLength(true).HasMaxLength(10);
            builder.Property(a => a.Email).IsRequired();
            builder.HasIndex(a => a.Email).IsUnique();
            
            builder.ToTable("Accounts");

        }
    }
}