using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Payments_Classes;

namespace DAL.Configurations
{
    public class CashConfiguration : IEntityTypeConfiguration<Cash>
    {
        public void Configure(EntityTypeBuilder<Cash> builder)
        {
            builder.Property(x => x.CasherName)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired(false);
            builder.Property(x => x.CashValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

        }
    }

}
