using eCommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DataAccess.Mapping.EF
{
    public class GenderMap :IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(
                new Gender
                {
                    Id = 1,
                    Description = "Kadın"
                },
                new Gender
                {
                    Id = 2,
                    Description = "Erkek"
                });
            
            builder.ToTable("Genders");
        }
    }
}