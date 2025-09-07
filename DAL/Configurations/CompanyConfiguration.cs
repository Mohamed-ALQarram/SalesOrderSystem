using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Customer_Classes;

namespace DAL.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CompanyName).HasColumnType("varchar").HasMaxLength(25)
                .IsRequired(false);
            builder.Property(x => x.Location).HasColumnType("varchar").HasMaxLength(100)
                .IsRequired(true);
        }
    }
}

