using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class ExchangeRateHistoryMap : IEntityTypeConfiguration<ExchangeRateHistory>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateHistory> builder)
        {
            builder.HasOne(e => e.Currency)
                .WithMany(c => c.ExchangeRateHistories)
                .HasForeignKey(e => e.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("ExchangeRateHistories");
        }
    }
}